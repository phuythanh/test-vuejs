import axios from 'axios'
import store from '@/store'
export const longRunTimeout = 40000
const http = axios.create({
  baseURL: 'https://api.covid19api.com',
  timeout: 20000,

})
http.interceptors.request.use(function (config) {
  const token = store.getters['User/token'];
  config.headers["X-Auth-Token"] = token;
  return config;
});

const reloadToHomePage = error => {
  if (
    error &&
    error.response &&
    error.response.status === 401
  ) {

    return true
  }
  return false
}
const formatError = err => {
  let message = 'Network error'
  // Axios response
  if (err.response) {
    if (
      err.response.data &&
      err.response.data.error &&
      err.response.data.message
    ) {
      message = `${err.response.data.error.toUpperCase()} <br /> ${err.response.data.message
        }`
    } else {
      message = `${err.config.method.toUpperCase()} ${err.response.status} ${err.response.request.responseURL
        } <br /> ${err.response.statusText}`
    }
  } else {
    // Generic error, don't know the format
    message = JSON.stringify(err)
  }
  return message
}

const handleResponse = response => {
  // Parse the axios response
  const success = response.status >= 200 && response.status < 300
  const data = response.data
  let message = response.statusText

  if (!success) {
    message = formatError(response)
    // Toast
    error(message)
  }

  return {
    success,
    data,
    message
  }
}

const handleNetworkError = err => {
  if (process.env.NODE_ENV !== 'production') {
    // Raw error should not make it to production
    console.error(err.response || err)
  }
  const message = formatError(err)
  // Toast
  error(message)
  return {
    success: false,
    message
  }
}

export const callApi = async (action, ignoreError = null) => {
  try {
    const response = await action
    return handleResponse(response)
  } catch (err) {
    if (reloadToHomePage(err)) return
    if (ignoreError) {
      return {
        success: false,
        message: err.response
      }
    }
    return handleNetworkError(err)
  } finally {
  }
}
export const get = async (url, config, ignoreError) => {
  return callApi(http.get(url, config), ignoreError)
}

export const put = async (url, payload, config) => {
  return callApi(http.put(url, payload, config))
}

export const post = async (url, payload, config) => {
  return callApi(http.post(url, payload, config))
}

export const del = async (url, payload) => {
  return callApi(http.delete(url, payload))
}

export default {
  install: instance => {
    instance.prototype.$http = {
      get,
      put,
      post,
      del
    }
  }
}
