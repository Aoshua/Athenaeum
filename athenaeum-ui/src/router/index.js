import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import Login from "../views/Account/Login.vue";
import Collections from "../views/Collections.vue";
import Profile from "../views/Account/Profile.vue";
import store from "../store";

Vue.use(VueRouter);

const checkLoginStatus = (to, from, next) => {
    if (store.state.loggedIn) {
        next();
    } else {
        next("/");
    }
};

const routes = [
    {
        path: "/",
        name: "Login",
        component: Login,
        beforeEnter(to, from, next) {
            if (store.state.loggedIn) {
                next("/Home");
            } else {
                next();
            }
        },
    },
    {
        path: "/home",
        name: "Home",
        component: Home,
        beforeEnter: checkLoginStatus
    },
    {
        path: "/about",
        name: "About",
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () => import(/* webpackChunkName: "about" */ "../views/About.vue"),
        beforeEnter: checkLoginStatus
    },
    {
        path: "/collections",
        name: "Collections",
        component: Collections,
        beforeEnter: checkLoginStatus
    },
    {
        path: "/profile",
        name: "Profile",
        component: Profile,
        beforeEnter: checkLoginStatus
    },
];

const router = new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes,
});

export default router;
