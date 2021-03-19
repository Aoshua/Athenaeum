<template>
    <div>
        <div class="wrapper box-shadow">
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
            <button class="btn btn-primary" @click="attemptLogin">Login</button>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';
    import store from '../../store/index.js';

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
                    console.log(response);
                })
                .catch((e) => {
                    console.log(e);
                });
        },
        methods: {
            attemptLogin() {
                //console.log(this.email);
                //console.log(this.password);

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
        width: 100%;
        min-height: 100%;
        padding: 20px;
    }
</style>
