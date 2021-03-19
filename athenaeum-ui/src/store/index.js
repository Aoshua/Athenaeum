import Vue from "vue";
import VueRouter from "vue-router";
import Vuex from "vuex";
import axios from 'axios';
import { colors } from '../assets/js/colors';

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        loggedIn: false,
        user: {},
        token: {},
        authHeader: {},
        isDarkMode: false,
        darkModeColors: colors.darkModeColors,
        lightModeColors: colors.lightModeColors,
        apiUrl: 'https://localhost:44343'
    },
    mutations: {
        logIn(state, data) {
            console.log('store > mutations > logIn');

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
        logIn(context, login) {
            //console.log('store > actions > logIn');
			return new Promise((resolve, reject) => {

				axios.post(`${this.state.apiUrl}/account/Authenticate`, 
					{
						email: login.username,
						password: login.password
					},
					this.state.authHeader
				).then(response => {
					context.commit('logIn', response.data);
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
