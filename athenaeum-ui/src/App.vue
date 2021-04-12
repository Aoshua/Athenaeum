<template>
    <div id="app">
        <div v-if="this.$store.state.loggedIn" >
            <div class="top-nav">
                <router-link to="/">Home</router-link> |
                <router-link to="/about">About</router-link>
            </div>
            <router-view style="margin-top: 50px;" />
        </div>
        <router-view v-else />
    </div>
</template>

<style scoped>
    .top-nav {
        width: 100%;
        height: 50px;
        background-color: var(--nav-c);
        top: 0;
        position: fixed;
        display: flex;
        align-items: center;
        padding: 0px 20px;
    }
</style>
