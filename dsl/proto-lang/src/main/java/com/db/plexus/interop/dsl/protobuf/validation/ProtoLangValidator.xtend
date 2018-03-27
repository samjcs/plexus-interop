/**
 * Copyright 2017 Plexus Interop Deutsche Bank AG
 * SPDX-License-Identifier: Apache-2.0
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
/*
 * generated by Xtext 2.12.0
 */
package com.db.plexus.interop.dsl.protobuf.validation

import org.eclipse.xtext.validation.Check
import com.db.plexus.interop.dsl.protobuf.Package
import com.db.plexus.interop.dsl.protobuf.ProtobufPackage
import com.google.inject.Inject
import org.eclipse.xtext.resource.IContainer
import org.eclipse.xtext.resource.impl.ResourceDescriptionsProvider
import com.db.plexus.interop.dsl.protobuf.NamedElement
import org.eclipse.xtext.resource.IEObjectDescription
import org.eclipse.xtext.naming.IQualifiedNameProvider
import com.db.plexus.interop.dsl.protobuf.Import
import com.db.plexus.interop.dsl.protobuf.ProtoLangImportResolver
import com.db.plexus.interop.dsl.protobuf.Field
import com.db.plexus.interop.dsl.protobuf.Proto
import com.db.plexus.interop.dsl.protobuf.ProtoLangConfig

/**
 * This class contains custom validation rules. 
 *
 * See https://www.eclipse.org/Xtext/documentation/303_runtime_concepts.html#validation
 */
class ProtoLangValidator extends AbstractProtoLangValidator {
	
	private static final char DOT_CHAR = '.'
	private static final char UNDERSCORE_CHAR = '_'
	
	@Inject
	IContainer.Manager containermanager;

	@Inject
	ResourceDescriptionsProvider resourceDescriptionsProvider;
		
	@Inject
	IQualifiedNameProvider qualifiedNameProvider;
	
	@Inject
	ProtoLangImportResolver importResolver
	
	@Inject
	ProtoLangConfig protoLangConfig
		
	@Check
	def checkSinglePackageDeclaration(Package ele) {		
		if (ele.eContainer.eContents.filter(typeof(Package)).length > 1) {					
			error('Duplicated package declaration', ProtobufPackage.Literals.PACKAGE__IMPORTED_NAMESPACE)
		}
	}
	
	@Check
	def checkFullNameIsUnique(NamedElement element) {
		val name = qualifiedNameProvider.getFullyQualifiedName(element)
		val resourceDescriptions = resourceDescriptionsProvider.getResourceDescriptions(element.eResource());
		val resourceDescription = resourceDescriptions.getResourceDescription(element.eResource().getURI());
		for (IContainer c : containermanager.getVisibleContainers(resourceDescription, resourceDescriptions)) {
			for (IEObjectDescription od : c.getExportedObjectsByType(ProtobufPackage.Literals.NAMED_ELEMENT)) {
				if (name.equals(od.getQualifiedName()) && !od.EObjectOrProxy.equals(element)) {
					error("Duplicated qualified name: " + name + ". " + od.EClass.name + " with the same qualified name is already defined in " + od.EObjectOrProxy.eResource.URI, ProtobufPackage.Literals.NAMED_ELEMENT__NAME);
				}
			}
		}
	}	
	
	@Check
	def checkImport(Import ele) {
		val path = ele.importURI
		if (importResolver.resolveURI(ele.eResource.resourceSet, path) === null) {
			val resolveCandidates = importResolver.getResolveCandidates(path)
			error('Imported resource cannot be resolved: ' + path + '. The following candidates were checked: ' + resolveCandidates, ProtobufPackage.Literals.IMPORT__IMPORT_URI);			
		}				
	}
	
	@Check
	def checkFieldNumbers(Field field) {
		var fields = field.eContainer.eContents.filter(typeof(Field))
		for (otherField: fields) {
			if (otherField.number == field.number && !otherField.equals(field)) {
				error('The same number assigned to field "' + otherField.name + '"', ProtobufPackage.Literals.FIELD__NUMBER)
			}			
		}
	}
	
	@Check
	def checkProtoResourceName(Proto proto) {
		if (!protoLangConfig.strictMode) {
			return
		}
		val fileName = proto.eResource.URI.lastSegment
		var isValid = true		
		for (var i=0; isValid && i<fileName.length; i++) {			
			val c = fileName.charAt(i)
			isValid = (Character.isLowerCase(c) && Character.isLetter(c)) || Character.isDigit(c) || c == UNDERSCORE_CHAR || c == DOT_CHAR
			if (!isValid){
				Character.isLowerCase(c)
			}
		}
		if (!isValid) {
			error('Resource name "' + fileName + '" is not valid. Only lower-case letters, digits, underscores and dots allowed.', proto, ProtobufPackage.Literals.PROTO__ELEMENTS)		
		}
	}
	
	@Check
	def checkPackageName(Package ^package) {
		if (!protoLangConfig.strictMode) {
			return
		}
		val name = ^package.importedNamespace
		var isValid = true		
		for (var i=0; isValid && i<name.length; i++) {			
			val c = name.charAt(i)
			isValid = (Character.isLowerCase(c) && Character.isLetter(c)) || Character.isDigit(c) || c == DOT_CHAR
			if (!isValid){
				Character.isLowerCase(c)
			}
		}
		if (!isValid) {
			error('Package name "' + name + '" is not valid. Only lower-case letters, digits, underscores and dots allowed.', ^package, ProtobufPackage.Literals.PACKAGE__IMPORTED_NAMESPACE)		
		}
	}
	
	@Check
	def checkProtoResourceLocation(Proto proto) {
		if (!protoLangConfig.strictMode) {
			return
		}
		val resource = proto.eResource
		val name = this.qualifiedNameProvider.getFullyQualifiedName(proto)		
		val segments = name.skipFirst(1).segments		
		val importPath = if (segments.length > 0) segments.join("/") + "/" + resource.URI.lastSegment else resource.URI.lastSegment
		val resolvedUri = this.importResolver.resolveURI(resource.resourceSet, importPath)	
		if (resolvedUri != resource.URI) {
			val candidates = this.importResolver.getResolveCandidates(importPath)
			error('Resource folder do not correspond to its package name "' + name.skipFirst(1) + '". Valid locations for the resource: ' + candidates, proto, ProtobufPackage.Literals.PROTO__ELEMENTS)
		}
	}		
}
