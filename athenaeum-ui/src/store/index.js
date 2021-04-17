import Vue from 'vue';
import Vuex from 'vuex';
import axios from 'axios';
//import { themes } from '../assets/js/themes';
import router from '../router/index';
import VueCookies from 'vue-cookies'
import createPersistedState from 'vuex-persistedstate';
import createMutationsSharer from 'vuex-shared-mutations';

Vue.use(Vuex);
Vue.use(VueCookies);

let session = Vue.$cookies.get('vuex');

function isDefined(value) {
    return (typeof value !== 'undefined' && value != null);
}

export default new Vuex.Store({
    state: {
        loggedIn: isDefined(session) ? session.loggedIn : false,
        user: isDefined(session) ? session.user : {},
        token: isDefined(session) ? session.token : {},
        authHeader: isDefined(session) ? session.authHeader : {},
        apiUrl: 'https://localhost:44343'
    },
    mutations: {
        logIn(state, data) {
            state.user = data.user;
            state.token = data.token;

            // TODO: If the tokenExpiration time has passed, refresh the token
            state.authHeader = {
                headers: {
                    Authorization: `Bearer ${data.token.accessToken}`
                }
            }

            state.loggedIn = true;
            router.push({ name: 'Home' });
        },
        logOut(state) {
            state.loggedIn = false;
            state.user = {};
            state.token = {};
            state.authHeader = {};
            Vue.$cookies.remove('vuex'); // Is this working?
        }
    },
    actions: {
        logIn(context, credentials) {
			return new Promise((resolve, reject) => {

				axios.post(`${this.state.apiUrl}/account/authenticate`, 
					{
						Email: credentials.email,
						Password: credentials.password
					}
				).then(r => {
					context.commit('logIn', r.data);
					resolve({
						success: true
					});
				}).catch(e => {
					reject({
						success: false,
						error: e
					});
				});
			})
		},
        logOut(context) {
            context.commit('logOut');
            router.push('/');
        }
    },
    plugins: [
        createPersistedState({ // Persists the Vuex state in cookies
            getItem: (key) => Vue.$cookies.get(key),
            setItem: (key, state) => {
                Vue.$cookies.set(key, state, '20h');
            }
        }),
        createMutationsSharer({ // Shares our mutations among browser tabs
            predicate: [
                'logIn',
                'logOut'
            ]
        })
    ]
});
