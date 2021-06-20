var app = new Vue({
  el: "#app",
    data: {
    appUrl:"http://localhost:23657",
    user_id: "0",
    restaurant: {
      user_ID: "",
      RestaurantName: "",
      Restaurantid: "",
      cityID: "",
      rating: "",
      destanec: "",
      postalCode: "",
      countryID: "",
    },
    listOfRestaurants: [],
    listOfBlacklistedRestaurants: [],
    blaklistedItemsForUser: [],
    messages: [
      {
        type: "", // sucess,error,etc..
        message: "",
      },
    ],
    errorOccured: false,
    errorMessage: "",
    warningMessage:"",
    infoMessage: "",
    pageIsloading: false,
    favoriteToogle: {
      userId: "",
      restaurant: {},
    },
    blacklistToogle: {
      userId: "",
      restaurantId: "",
      favorite: false,
    },
  },
  methods: {
    setAsFavorite: function (r) {
          this.restaurant.Restaurantid = r.id.toString();
          var URL = this.appUrl + "/api/Favorite/Favorite"
      axios
        .post(URL,this.restaurant
        )
        .then(
          function (response) {
            this.errorMessage = "";
            this.infoMessage = "";
            this.listOfRestaurants = response.data;
            this.blaklistedItemsForUser = response.data[0].blackLists;

            //search();
          }.bind(this)
        )
        .catch(
          function (error) {
            if (error.response) {
              console.log(error.response.data);
            }
            this.error = true;
            this.isloading = false;
          }.bind(this)
        );
    },
    removeBL: function () {
          var URL = this.appUrl +"/api/BlackList/delete"
      axios
        .post(URL,this.restaurant
        )
        .then(
          function (response) {
            this.listOfRestaurants = response.data;
            this.isloading = false;
          }.bind(this)
        )
        .catch(
          function (error) {
            if (error.response) {
              console.log(error.response.data);
            }
            this.error = true;
            this.isloading = false;
          }.bind(this)
        );
    },
    onselectedChange: function (event) {
      this.user_id = event.target.value;
    },
    RemoveAllBlacklist: function () {
      this.restaurant.Restaurantid = this.user_id.toString();
      this.listOfBlacklistedRestaurants = "";
      var URL = this.appUrl + "/api/BlackList/Delete";
      axios
        .post(URL,this.restaurant
        )
        .then(
          function (response) {
            this.listOfBlacklistedRestaurants = response.data;
            this.isloading = false;
                this.infoMessage = "all blacklist was removed"
                this.GetRestaurants(this.restaurant);
          }.bind(this)
        )
        .catch(
          function (error) {
            if (error.response) {
              console.log(error.response.data);
            }
            this.error = true;
            this.isloading = false;
          }.bind(this)
        );
    },
    setAsBlacklist: function (r) {
        this.restaurant.Restaurantid = r.id.toString();
        URL = this.appUrl + "/api/BlackList/Blacklist";
        axios
        .post(URL,this.restaurant)
        .then(
          function (response) {
            this.listOfRestaurants = response.data;
            this.isloading = false;
          }.bind(this)
        )
        .catch(
          function (error) {
            if (error.response) {
              console.log(error.response.data);
            }
            this.error = true;
            this.isloading = false;
          }.bind(this)
        );
    },
    submitsearch: function () {
        GetRestaurants(this.restaurant);
    },
    sortlist: function (by) {
        this.errorMessage = "";
         
            this.listOfRestaurants = _.sortBy(this.listOfRestaurants, by);

        },
    GetRestaurants: function () {
      this.listOfRestaurants = [];
      this.pageIsloading = true;
      this.errorMessage = "";
      var URL = this.appUrl + "/api/restaurants";
      axios
        .get(URL)
        .then((response) => {
          this.pageIsloading = false;
          this.listOfRestaurants = response.data;
        })
        .catch((error) => {
          this.pageIsloading = false;
          this.errorOccured = false;
          errorMessage = "";
        })
        .finally(() => (this.loading = false));
    },
    search: function () {
        this.restaurant.user_ID = parseInt(this.restaurant.user_ID);
        var URL = this.appUrl + "/api/restaurants/search";
        this.errorMessage= "",
        this.warningMessage= "",
        this.infoMessage= "",
       axios
      .post(URL ,this.restaurant)
      .then(
          function (response) {
            if (response.statusText == "OK") {
              this.errorMessage = "";
              this.infoMessage = "";
              this.listOfRestaurants = response.data;
              this.blaklistedItemsForUser = response.data[0].blackLists;
            } else if (response.statusText == "No Content") {
                this.warningMessage = "No Data Found - Please try another search";
               
              this.listOfRestaurants = "";
            }

            this.pageIsloading = false;
          }.bind(this)
        )
      .catch(
          function (error) {
            if (error.response) {
              this.pageIsloading = false;
              this.errorOccured = false;
              errorMessage = error.message;
              console.log(error.response.data);
              this.listOfRestaurants = "";
            }
          }.bind(this)
        );
    },
    }
});
