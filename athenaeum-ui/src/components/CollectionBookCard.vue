<template>
    <div class="col-lg-4 col-md-6 col-sm-12 mt-1 mb-2">
        <div class="ath-card">
            <h5 style="color: var(--pri-c);">{{ record.book.title }}</h5>
            <div v-if="record.book.seriesTitle" class="mb-1" style="margin-top: -10px;">
                {{ record.book.seriesTitle }}
            </div>
            <div class="row">
                <div class="col-6">
                    Published:
                </div>
                <div class="col-6">
                    {{ toLocalDate(record.publicationDate) }}
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    Pages:
                </div>
                <div class="col-6">
                    {{ record.book.pageCount }}
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: "CollectionBookCard",
        props: {
            record: Object,
        },
    };
</script>
