/**
 * Copyright 2017-2020 Plexus Interop Deutsche Bank AG
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
import { transportProtocol as plexus } from '@plexus-interop/protocol';

/**
 * Same as RxJS Observer, with optional Plexus completion 
 */
export interface PlexusObserver<T> {
    next: (value: T) => void;
    error: (err: any) => void;
    complete: (completion?: plexus.ICompletion) => void;
}

export interface PlexusNextObserver<T> {
    closed?: boolean;
    next: (value: T) => void;
    error?: (err: any) => void;
    complete: (completion?: plexus.ICompletion) => void;
}

export interface PlexusErrorObserver<T> {
    closed?: boolean;
    next?: (value: T) => void;
    error: (err: any) => void;
    complete: (completion?: plexus.ICompletion) => void;
}

export interface CompletionObserver<T> {
    closed?: boolean;
    next?: (value: T) => void;
    error?: (err: any) => void;
    complete: (completion?: plexus.ICompletion) => void;
}

export declare type PlexusPartialObserver<T> = PlexusNextObserver<T> | PlexusErrorObserver<T> | CompletionObserver<T>;