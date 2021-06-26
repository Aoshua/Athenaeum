<template>
    <div class="home">
        <div class="d-flex justify-content-between">
            <h3>{{ collectionTitle }}</h3>
            <h4>Books: {{ numBooks }}</h4>
        </div>
        <div class="row mb-3">
            <collection-book-card v-for="record in records" :key="record.BookID" :record="record" />
            <collection-book-card v-for="record in records" :key="record.BookID" :record="record" />
            <collection-book-card v-for="record in records" :key="record.BookID" :record="record" />
        </div>
    </div>
</template>

<script>
    import store from "../store/index"
    import axios from "axios"
    import CollectionBookCard from "../components/CollectionBookCard"

    export default {
        name: "Home",
        components: {
            CollectionBookCard
        },
        data() {
            return {
                records: [],
                collectionTitle: "",
                numBooks: 0
            };
        },
        mounted() {
            this.loadCollection();
        },
        methods: {
            logOut() {
                store.dispatch("logOut");
            },
            async loadCollection() {
                let colUrl = `${store.state.apiUrl}/collection/getBooksInDefaultCollection?userId=${store.state.user.userId}`;

                let r = await axios.get(colUrl, store.state.authHeader);
                this.collectionTitle = r.data.collectionTitle;
                this.numBooks = r.data.recordCount;
                this.records = r.data.records;
                console.log(this.records);
            },
        },
    };
</script>
