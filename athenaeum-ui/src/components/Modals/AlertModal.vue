<template>
    <div class="modal fade" :id="id" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="d-flex justify-content-end">
                    <div data-dismiss="modal" aria-label="Close" style="padding: .5rem 1rem; cursor: pointer">
                        <i class="fa fa-times"></i>
                    </div>
                </div>
                <div class="modal-body">
                    {{ message }}
                </div>
                <div class="modal-footer" style="border-top: none; padding: 5px">
                    <button ref="cancelAlert" class="btn btn-sec-ol btn-login mb-2" data-dismiss="modal">{{ noText }}</button>
                    <button class="btn btn-pri-ol btn-login mb-2" @click="$emit('approve'); $refs.cancelAlert.click()">{{ yesText }}</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: "AlertModal",
        props: {
            id: {
                type: String,
                default: "alertModal",
            },
            message: {
                type: String,
                default: "Confirm?",
            },
            yesText: {
                type: String,
                default: "Yes",
            },
            noText: {
                type: String,
                default: "No",
            },
        },
    };
</script>

<style scoped>
    .modal-content {
        background-color: var(--background-c);
    }
</style>
