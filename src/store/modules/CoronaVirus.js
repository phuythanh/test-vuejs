import { get, post, put, del } from '@/plugins/http-client'
import {
  FETCH_CORONA_SUMMARY,
  FETCH_COUNTRIES,
  SET_COUNTRY
} from '@/store/actionNames'

const state = {
  countryDetail: {},
  countries: [],
  countrySummary: {}
}

const mutations = {
  [FETCH_CORONA_SUMMARY]: (state, countrySummary) => {
    state.countrySummary = countrySummary
  },
  [FETCH_COUNTRIES]: (state, countries) => {
    state.countries = countries
  },
  [SET_COUNTRY]: (state, countryDetail) => {
    state.countryDetail = countryDetail
  }
}

const actions = {
  [FETCH_CORONA_SUMMARY]: async ({ commit }) => {
    const result = await get(`/summary`)
    if (result.success) {
      commit(FETCH_CORONA_SUMMARY, result.data)
      commit(SET_COUNTRY, result.data.Global)
    }
  },
  [FETCH_COUNTRIES]: async ({ commit }) => {
    const result = await get(`/countries`)
    if (result.success) {
      commit(FETCH_COUNTRIES, result.data)
    }
  },
  [SET_COUNTRY]: async ({ commit }, data) => {
    commit(SET_COUNTRY, data)
  }
}

const getters = {
  countries: state => state.countries,
  countryDetail: state => state.countryDetail,
  countrySummary: state => state.countrySummary
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
