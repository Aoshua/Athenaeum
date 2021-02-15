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
    export default {
        name: "Login",
        data() {
            return {
                email: "",
                password: "",
            };
        },
        methods: {
            attemptLogin() {
                console.log(this.email);
                console.log(this.password);
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
