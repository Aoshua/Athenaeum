import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import "./assets/css/ath-root.css";

Vue.config.productionTip = false;

Vue.mixin({
    methods: {
		toLocalDate(str) {
			var date = new Date(str)
			return date.toLocaleDateString(date)
		}
	},
});

new Vue({
    router,
    store,
    render: (h) => h(App),
}).$mount("#app");
