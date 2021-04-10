<template>
    <div class="l-page">
        <div class="wrapper">
            <div class="row">
                <div class="col-12">
                    <h2>.athenaeum</h2>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-12">
                    <input type="email" class="form-control" v-model="email" placeholder="Email" />
                </div>
                <div class="form-group col-12">
                    <input type="password" class="form-control" v-model="password" placeholder="Password" />
                </div>
            </div>
            <div class="btn-cont">
                <button class="btn btn-pri" @click="attemptLogin" style="margin-right: 10px;">Login</button>
                <button class="btn btn-sec" @click="attemptLogin">Register</button>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from "axios";
    import store from "../../store/index.js";

    export default {
        name: "Login",
        data() {
            return {
                email: "",
                password: "",
            };
        },
        mounted() {
            axios
                .get(`${store.state.apiUrl}/application/testconnection`)
                .then((response) => {
                    console.log(response.data);
                })
                .catch((e) => {
                    console.log(e);
                });
        },
        methods: {
            attemptLogin() {
                this.$store
                    .dispatch("logIn", {
                        email: this.email,
                        password: this.password,
                    })
                    .then(
                        (r) => {
                            if (r.success == true) this.error = false;
                            else console.log(r.error);
                        },
                        (error) => {
                            this.error = true;
                            console.log("From login.vue", error);
                        }
                    );
            },
        },
    };
</script>

<style scoped>
    .wrapper {
        display: flex;
        align-items: center;
        flex-direction: column;
        justify-content: center;
        padding: 20px;
        background-color: var(--card-c);
        width: 550px;
        border-radius: 15px;
    }

    .l-page {
        display: flex;
        justify-content: center;
        margin: 4rem 0.75rem;
    }

    .btn-cont {
        display: flex;
    }
</style>
