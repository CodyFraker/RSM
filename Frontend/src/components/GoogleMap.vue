<template>
    <div>
      <div>
        <b-form inline>
          <b-button variant="warning" @click="clearMap()">Remove Markers</b-button>
        <GmapAutocomplete
          :selectFirstOnEnter="true"
          @place_changed='setPlace'/>
        </b-form>

      </div>
      <br>
      <GmapMap
        :center='brewerycenter || selectedCity.coordinates'
        :zoom='9'
        style='width:100%; height: 600px;'>

        <GmapMarker
          :key="index"
          v-for="(m, index) in markers"
          :position="m.position"
          @click="center=m.position"
        />
      </GmapMap>
    </div>
  </template>

<script>
export default {
  name: 'GoogleMap',
  props: ['markers', 'brewerycenter'],
  data() {
    return {
      currentPlace: null,
      places: [],
      selectedCity: {
        name: 'Harrisburg',
        state: 'Pennsylvania',
        coordinates: {
          lat: 40.2731911,
          lng: -76.8867008,
        },
      },
    };
  },
  mounted() {
    this.$emit('setcity', this.selectedCity);
  },
  methods: {
    setPlace(place) {
      this.selectedCity = {
        name: place.address_components[0].long_name,
        state: place.address_components[2].long_name,
        coordinates: {
          lat: parseFloat(place.geometry.location.lat()),
          lng: parseFloat(place.geometry.location.lng()),
        },
      };
      this.$emit('setcity', this.selectedCity);
    },
    clearMap() {
      this.$emit('clearmarks');
    },
  },
};
</script>
