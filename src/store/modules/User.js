import { post } from '@/plugins/http-client'
import {
  LOGIN,
} from '@/store/actionNames'

const state = {
  user: null
}

const mutations = {
  [LOGIN]: (state, user) => {
    state.user = user
  },
}

const actions = {
  [LOGIN]: async ({ commit }, { name, password }) => {
    let auth = {
      username: name,
      password: password
    }
    const result = await post(`/auth/access_token`, {}, {
      auth
    })
    if (result.success) {
      commit(LOGIN, result.data)
    }
    return result.success
  },

}

const getters = {
  user: state => state.user,
  token: state => state.user && state.user.Key,
  isAuthenticated: state => state.user != null
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
