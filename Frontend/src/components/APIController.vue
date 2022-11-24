<template>
<div class="hello">
    <h1>{{ msg }}</h1>
    <button @click="fetchData">Click Me!</button>
</div>
</template>
<script>
export default {
  name: 'ApiController',
  props: {
    msg: String,
  },
  methods: {
    fetchData() {
      fetch('https://api.openbrewerydb.org/breweries?by_dist=40.2731911,-76.8867008&per_page=5', {
        method: 'GET',
      })
        .then((response) => {
          response.json().then((res) => console.log(res));
        })
        .catch((err) => {
          console.error(err);
        });
    },
  },
};

</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
button {
padding: 20px 60px;
font-size: 18px;
}
</style>
