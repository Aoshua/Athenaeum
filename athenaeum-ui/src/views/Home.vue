<template>
    <div class="home">
        <div>

        </div>
    </div>
</template>

<script>
    // @ is an alias to /src
    import store from '../store/index';

    export default {
        name: "Home",
        methods: {
            logOut() {
                store.dispatch("logOut");
            }
        },
    };
</script>
