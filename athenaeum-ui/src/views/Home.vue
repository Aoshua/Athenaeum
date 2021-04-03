<template>
    <div class="home">
        <img alt="Vue logo" src="../assets/logo.png" />
        <HelloWorld msg="Welcome to Your Vue.js App" />
        <button @click="logOut">Log Out</button>
    </div>
</template>

<script>
    // @ is an alias to /src
    import HelloWorld from "@/components/HelloWorld.vue";
    import store from '../store/index';

    export default {
        name: "Home",
        components: {
            HelloWorld,
        },
        methods: {
            logOut() {
                store.dispatch("logOut");
            }
        },
    };
</script>
