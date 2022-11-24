import Vue from 'vue';
import VueRouter from 'vue-router';
import * as VueGoogleMaps from 'vue2-google-maps';
import VuetifyGoogleAutocomplete from 'vuetify-google-autocomplete';
import MainView from '../views/MainView.vue';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'home',
    component: MainView,
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue'),
  },
];

Vue.use(VueGoogleMaps, {
  load: {
    key: process.env.VUE_APP_GOOGLE_MAPS_API_TOKEN,
    libraries: 'places,visualization,drawing',
  },
  installComponents: true,
});

Vue.use(VuetifyGoogleAutocomplete, {
  apiKey: process.env.VUE_APP_GOOGLE_MAPS_API_TOKEN,
  installComponents: true,
  vueGoogleMapsCompatibility: true,
});

const router = new VueRouter({
  routes,
  history: true,
});

export default router;
