<template>
  <div class="about">
    <el-form ref="form" :model="form" label-width="120px">
      <el-form-item label="User name">
        <el-input v-model="form.name"></el-input>
      </el-form-item>
      <el-form-item label="Password">
        <el-input v-model="form.password" type="password"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="onSubmit">Login</el-button>
        <el-button>Cancel</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import { mapActions } from "vuex";
import { LOGIN } from "../store/actionNames";
export default {
  data() {
    return {
      form: {
        name: "",
        password: "",
      },
    };
  },
  methods: {
    ...mapActions("User", {
      login: LOGIN,
    }),
    async onSubmit() {
      if (await this.login(this.form)) {
        console.log("submit!");
        this.$router.push({ name: "Home" });
      }
    },
  },
};
</script>