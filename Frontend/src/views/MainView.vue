<template>
  <div class="home">
    <GoogleMap
      :markers="breweryMarks"
      :brewerycenter="brewerycenter"
      v-on:setcity="onSetCity"
      v-on:clearmarks="onClearMap" />
    <div>
      <b-container class="bv-example-row" fluid>
        <b-row>
          <b-col>
            <b-form-row>
            <b-col class="my-1">
              <b-form-group
                label="Per page"
                label-for="per-page-select"
                label-cols-sm="6"
                label-cols-md="4"
                label-cols-lg="3"
                label-align-sm="right"
                label-size="sm"
                class="mb-0">

                <b-form-select id="per-page-select"
                v-model="perPage"
                :options="pageOptions" s
                ize="sm">
                </b-form-select>
              </b-form-group>
            </b-col>
            <b-col class="my-1">
              <b-pagination
              v-model="currentPage"
              :total-rows="totalRows"
              :per-page="perPage"
              :hide-goto-end-buttons="true"
              align="fill"
              size="sm"
              class="my-0"
              @input="getData">
            </b-pagination>
            </b-col>
          </b-form-row>
            <b-table table-dark
            id="brewtable"
            ref="selectableTable"
            :items="breweries"
            :fields="fields"
            :busy.sync="isBusy"
            :no-provider-paging="true"
            select-mode="single"
            selectable
            @row-clicked="onRowSelected"
            hover
            responsive="sm">

            <template #cell(website_url)="data">
              <a :href="`${data.item.website_url}`" target="_blank">{{data.item.website_url}}</a>
            </template>
          </b-table>
          </b-col>
          <b-col cols="4" v-if="brewerySelected">
            <b-card header="Selected Brewery Details">
    <b-list-group>
    <b-list-group-item class="d-flex justify-content-between align-items-center">
      Name:
      <span>{{brewerySelected.name}}</span>
    </b-list-group-item>
    <b-list-group-item class="d-flex justify-content-between align-items-center">
      Type:
      <span>{{brewerySelected.type}}</span>
    </b-list-group-item>
    <b-list-group-item class="d-flex justify-content-between align-items-center">
      Street:
      <span>{{brewerySelected.street}}</span>
    </b-list-group-item>
    <b-list-group-item class="d-flex justify-content-between align-items-center">
      City:
      <span>{{brewerySelected.city}}</span>
    </b-list-group-item>
    <b-list-group-item class="d-flex justify-content-between align-items-center">
      State:
      <span>{{brewerySelected.state}}</span>
    </b-list-group-item>
    <b-list-group-item class="d-flex justify-content-between align-items-center">
      Coordinates:
      <span>{{brewerySelected.coordinates.lat}},{{brewerySelected.coordinates.lng}}</span>
    </b-list-group-item>
    <b-list-group-item class="d-flex justify-content-between align-items-center">
      Phone:
      <span>{{brewerySelected.phone}}</span>
    </b-list-group-item>
    <b-list-group-item class="d-flex justify-content-between align-items-center">
      Postal:
      <span>{{brewerySelected.postal}}</span>
    </b-list-group-item>
    </b-list-group>
  </b-card>
          </b-col>
        </b-row>
      </b-container>
    </div>
  </div>
</template>

<script>
import GoogleMap from '@/components/GoogleMap.vue';

const axios = require('axios');

export default {
  name: 'GoogleMapView',
  data() {
    return {
      fields: [
        { key: 'name' },
        { key: 'brewery_type' },
        { key: 'street' },
        { key: 'website_url' },
      ],
      pageOptions: [10, 20, 30, 50],
      currentPage: 1,
      perPage: 10,
      breweries: [],
      breweryMarks: [],
      isBusy: false,
      city: null,
      totalRows: 1,
      brewerySelected: {
        coordinates: false,
      },
    };
  },
  computed: {
    brewerycenter() {
      if (this.brewerySelected.coordinates.lat !== 'N/A') {
        return this.brewerySelected.coordinates;
      }
      return false;
    },
  },
  methods: {
    async getData() {
      this.isBusy = true;
      try {
        const response = await axios.get(`https://api.openbrewerydb.org/breweries?by_city=${this.city.name}&by_state=${this.city.state}&per_page=${this.perPage}&page=${this.currentPage}`);

        this.totalRows = this.currentPage * this.perPage
        + (response.data.length === this.perPage ? 1 : 0);
        this.breweries = response.data;
        this.isBusy = false;
      } catch (error) {
        this.isBusy = true;
      }
      this.onClearMap();
    },
    addMarker() {
      console.log(this.brewerySelected.coordinates.lat);
      if (this.brewerySelected.coordinates.lat === 'N/A') {
        return;
      }
      this.breweryMarks.push({ position: this.brewerySelected.coordinates });
    },
    onSetCity(city) {
      this.city = city;
      this.getData();
    },
    onRowSelected(item) {
      this.brewerySelected = {
        name: item.name,
        type: item.brewery_type,
        street: item.street || 'N/A',
        city: item.city || 'N/A',
        state: item.state || 'N/A',
        coordinates: {
          lat: parseFloat(item.latitude) || 'N/A',
          lng: parseFloat(item.longitude) || 'N/A',
        },
        country: item.country || 'N/A',
        phone: item.phone || 'N/A',
        postal: item.postal_code || 'N/A',
      };
      this.addMarker();
    },
    onClearMap() {
      this.breweryMarks = [];
    },
  },
  components: {
    GoogleMap,
  },
};
</script>
