<template>
	<div class="l-page">
		<div class="wrapper">
			<div style="width: 100%">
				<div class="mb-4 text-center">
					<h2>Athenaeum</h2>
				</div>
				<div class="form-group">
					<div class="mb-4">
						<input type="email" class="form-control" v-model="email" placeholder="Email" />
					</div>
					<div class="mb-4">
						<input type="password" class="form-control" v-model="password" placeholder="Password" />
					</div>
				</div>
				<!-- <button class="btn btn-pri btn-login mb-2" @click="attemptLogin">Login</button> -->
				<button class="btn btn-sec btn-login mb-2" @click="attemptLogin">Login</button>
				<!-- <button class="btn btn-ter btn-login mb-2" @click="attemptLogin">Login</button> -->
				<!-- <button class="btn btn-qua btn-login mb-2" @click="attemptLogin">Login</button> -->
				<!-- <button class="btn btn-qui btn-login mb-2" @click="attemptLogin">Login</button> -->
				<button class="btn btn-pri-ol btn-login mb-2" @click="attemptLogin">Register</button>
				<!-- <button class="btn btn-sec-ol btn-login mb-2" @click="attemptLogin">Register</button> -->
				<!-- <button class="btn btn-ter-ol btn-login mb-2" @click="attemptLogin">Register</button> -->
				<!-- <button class="btn btn-qua-ol btn-login mb-2" @click="attemptLogin">Register</button> -->
				<!-- <button class="btn btn-qui-ol btn-login mb-2" @click="attemptLogin">Register</button> -->
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
		width: 400px;
        height: 350px;
		border-radius: 7px;
		margin: 9rem 0.75rem;
		box-shadow: 0 1px 4px 0 rgb(0 0 0 / 14%);
	}

	.l-page {
		display: flex;
		justify-content: center;
		background-image: linear-gradient(50deg, rgba(0,0,0, .9) 0%, rgba(26,32,53, .9) 100%), url("../../assets/img/books1.jpg");
		height: 100vh;
		width: 100vw;
	}

	.btn-cont {
		display: block;
	}

	.btn-login {
		width: 100%;
	}
</style>
