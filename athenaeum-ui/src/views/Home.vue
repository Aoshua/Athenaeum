<template>
    <div class="home">
        <div>

        </div>
    </div>
</template>

<script>
    import store from '../store/index';
    import axios from 'axios';

    export default {
        name: "Home",
        data() {
            return {
                books: []
            }
        },
        mounted() {

        },
        methods: {
            logOut() {
                store.dispatch("logOut");
            },
            async loadCollection() {
                let colUrl = `${store.state.apiUrl}/collection/getDefaultCollection?userId=${store.state.user.userId}`;
                this.books = await axios.get(colUrl);
            }
        },
    };
</script>
