<template>
    <div id="app">
        <div v-if="this.$store.state.loggedIn">
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
                        <span class="tip-text">Profile</span>
                    </router-link>
                    <div class="ath-link menu-icon tip-cont" data-toggle="modal" data-target="#exampleModal">
                        <i class="fal fa-sign-out-alt fa-lg"></i>
                        <span class="tip-text" style="margin-left: -100px;">Logout</span>
                    </div>
                </div>
            </div>
            <router-view style="height: calc(100vh - 50px); margin-top: 50px; overflow: auto; padding: 10px" />
        </div>
        <router-view v-else />

        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="d-flex justify-content-end">
                        <div data-dismiss="modal" aria-label="Close" style="padding: .5rem 1rem; cursor: pointer">
                            <i class="fa fa-times"></i>
                        </div>
                    </div>
                    <div class="modal-body">
                        Are you sure you want to log out?
                    </div>
                    <div class="modal-footer" style="border-top: none; padding: 5px">
                        <button class="btn btn-sec-ol btn-login mb-2">Cancel</button>
                        <button class="btn btn-pri-ol btn-login mb-2">Logout</button>
                    </div>
                </div>
            </div>
        </div>
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

    .modal-content {
        background-color: var(--background-c);
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
        background-color: rgba(0, 0, 0, 0.9);
        color: var(--pri-f-c);
        text-align: center;
        padding: 5px 0px;
        border-radius: 6px;
        z-index: 1;
        opacity: 0;
        transition: opacity 0.6s;

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
