import { StudioState } from './model';
import {
  ActionReducerMap,
  createSelector,
  createFeatureSelector,
  ActionReducer,
  MetaReducer,
} from '@ngrx/store';
import { environment } from '../../environments/environment';
import { RouterStateUrl } from './utils';

import * as fromRouter from '@ngrx/router-store';
import * as fromPlexus from './reducers/plexus';

export interface State {
  plexus: StudioState;
  routerReducer: fromRouter.RouterReducerState<RouterStateUrl>;
}

/**
 * Our state is composed of a map of action reducer functions.
 * These reducer functions are called with each dispatched action
 * and the current or initial state and return a new immutable state.
 */
export const reducers: ActionReducerMap<State> = {
  plexus: fromPlexus.reducer,
  routerReducer: fromRouter.routerReducer,
};

export function logger(reducer: ActionReducer<State>): ActionReducer<State> {
  return function (state: State, action: any): State {
    let result = reducer(state, action);
    
    console.log('action: ', action);
    console.log('state: ', result);  

    return result;
  };
}

/**
 * By default, @ngrx/store uses combineReducers with the reducer map to compose
 * the root meta-reducer. To add more meta-reducers, provide an array of meta-reducers
 * that will be composed to form the root meta-reducer.
 */
export const metaReducers: MetaReducer<State>[] = [logger];

/**
 * Layout Reducers
 */
// export const getLayoutState = createFeatureSelector<fromLayout.State>('layout');
