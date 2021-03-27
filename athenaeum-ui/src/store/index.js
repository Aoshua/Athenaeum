import Vue from "vue";
import VueRouter from "vue-router";
import Vuex from "vuex";
import axios from 'axios';
//import { themes } from '../assets/js/themes';

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        loggedIn: false,
        user: {},
        token: {},
        authHeader: {},
        isDarkMode: false,
        apiUrl: 'https://localhost:44343'
    },
    mutations: {
        logIn(state, data) {
            console.log('store > mutations > logIn');
            console.log(data);
            
            state.user = data.user;
            state.token = data.token;

            // TODO: If the tokenExpiration time has passed, refresh the token
            state.authHeader = {
                header: {
                    Authorization: `Bearer ${data.token.accessToken}`
                }
            }

            state.isLoggedIn = true;
            VueRouter.push({ name: 'Home' });
        }
    },
    actions: {
        logIn(context, credentials) {
            //console.log('store > actions > logIn');
            //console.log(credentials.email);
            //console.log(credentials.password);

			return new Promise((resolve, reject) => {

				axios.post(`${this.state.apiUrl}/account/authenticate`, 
					{
						Email: credentials.email,
						Password: credentials.password
					},
					this.state.authHeader
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
    },
    modules: {},
});
