import { expect } from 'chai'
import { shallowMount, createLocalVue } from '@vue/test-utils'
import Countries from '@/components/Countries.vue'
import Vuex from 'vuex'
const localVue = createLocalVue()
localVue.use(Vuex)
describe('Countries.vue', () => {
  let store
  let getters
  let state = {
    articles: [
      {
        title: "Testing Vue Components"
      },
      {
        title: "This One shows",
        text: "<p>You can see me!</p>"
      }

    ]
  }

  beforeEach(() => {
    getters = {
      articles: () => {
        return state.articles
      },
      userArticles: () => {
        return state.userArticles
      }
    }

    store = new Vuex.Store({ getters })
  })

  it('renders props.msg when passed', () => {

    const msg = 'new message'
    const wrapper = shallowMount(Countries, {
      store,
      localVue
    })
    expect(wrapper.text()).to.include(msg)
  })
})
