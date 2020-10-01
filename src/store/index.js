import Vue from 'vue'
import Vuex from 'vuex'
import VuexPersist from 'vuex-persist'

import modules from './modules'

Vue.use(Vuex)

const vuexLocalStorage = new VuexPersist({
  key: 'user-token',
  storage: window.localStorage,
  reducer: state => ({
    User: state.User
  })
})

export default new Vuex.Store({
  modules,
  plugins: [vuexLocalStorage.plugin],
  strict: process.env.NODE_ENV !== 'production'
})
