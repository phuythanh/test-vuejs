import { get, post, put, del } from '@/plugins/http-client'
import {
  VIEW_PDF
} from '@/store/actionNames'

const state = {
}

const mutations = {
}

const actions = {
  [VIEW_PDF]: async ({ commit }) => {
    window.open('http://localhost:64591/api/report/exportpdf', '_blank');
    // const result = await get(`http://localhost:64591/api/report/exportpdf`)
    // debugger
    // if (result.success) {
    //   return result.data
    // }
  },

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
