<template>
    <div>
        <p>Are you sure you want to delete this card? {{ card.term }}</p>
        <button id="delete-confirm" class="form-button" v-on:click="submitDelete">Yes, delete</button>

    </div>
</template>

<script>
import CardService from '../services/CardService';

export default {
    props: {
        card: {
            type: Object,
            required: true
        },
    },
    data() {
        return {
            deleteCard: {
                cardId: this.card.cardId,
                deckId: parseInt(this.$route.params.deckId),
                term: this.card.term,
                definition: this.card.definition,
                userId: this.card.userId
            }
        }

    },
    methods: {
        submitDelete() {
            CardService
                .deleteCardFromDeck(this.deleteCard)
                .then(response => {
                    if (response.status === 204) {
                        console.log("reached delete card in delete confirmation")
                        this.$store.commit(
                            'SET_NOTIFICATION',
                            {
                                message: 'A card was deleted.',
                                type: 'success'
                            }
                        );
                        window.location.reload();
                    }
                })
                .catch(error => {
                    /**this.handleErrorResponse(error, 'adding');*/
                })
        }
    }

}

</script>

<style>
#delete-confirm {
    background-color: #d88c8c;
    box-shadow: 0 0 0.25rem #a85f5f;
    border: 0.05rem solid #a85f5f;
}
</style>