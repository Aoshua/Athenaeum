<template>
    <div id="app">
        <div v-if="this.$store.state.loggedIn" >
            <div class="top-nav">
                <div>
                    <router-link to="/" class="ath-link" style="font-size: 1.2rem">Athenaeum</router-link>
                </div>
                <div>
                    <router-link to="/collections" class="ath-link menu-icon tip-cont">
                        <i class="fal fa-books fa-lg"></i>
                        <span class="tip-text">Collections</span>
                    </router-link>
                    <router-link to="/profile" class="ath-link menu-icon tip-cont">
                        <i class="fal fa-user fa-lg"></i>
                        <span class="tip-text" style="margin-left: -100px;">Profile</span>
                    </router-link>
                </div>
            </div>
            <router-view style="height: calc(100vh - 50px); margin-top: 50px; overflow: auto;" />
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
        justify-content: space-between;
        align-items: center;
        padding: 0px 20px;
    }

    .menu-icon {
        margin-left: 15px;
    }

    .tip-cont {
        position: relative;
        display: inline-block;
    }

    .tip-cont .tip-text {
        visibility: hidden;
        width: 120px;
        background-color: rgba(0, 0, 0, .4);
        color: var(--pri-f-c);
        text-align: center;
        padding: 5px 0px;
        border-radius: 6px;
        z-index: 1;
        opacity: 0;
        transition: opacity .6s;

        position: absolute;
        top: 135%;
        left: 50%;
        margin-left: -60px;
    }

    .tip-cont:hover .tip-text {
        visibility: visible;
        opacity: 1;
    }
</style>
