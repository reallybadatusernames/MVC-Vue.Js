var Games = {
    vue: null,
    vueConfig: {
        el: "#main",
        data: {
            games: []
        },
        methods: {
            load: function () {
                let self = this;
                $.ajax({
                    url: '/games/get-games',
                    type: 'get',
                    success: function (data) {
                        self.games = data.Games;
                    },
                    error: function (i, j, k) {
                        console.log(i);
                    }
                })
            },
            deleteGame: function (id) {
                let self = this;
                $.ajax({
                    url: '/games/delete-game',
                    data: { Id: id},
                    type: 'post',
                    success: function (data) {
                        self.load();
                    },
                    error: function (i, j, k) {
                        console.log(i);
                    }
                })
            }
        }
    },
    init: function () {
        //for development purposes. When going to production make sure to use vue.min.js and remove the following:
        Vue.config.silent = false;
        Vue.config.debug = true;

        //init vue
        Games.vue = new Vue(Games.vueConfig);
        Games.vue.load();
    }
}

document.addEventListener('DOMContentLoaded', function (evt) { Games.init() })