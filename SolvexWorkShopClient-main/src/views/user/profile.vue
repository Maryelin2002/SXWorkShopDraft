<template>
  <div class="profile">
    <b-collapse class="card" animation="slide" aria-id="contentIdFor">
      <template #trigger="props">
        <div class="card-header" role="button" aria-controls="contentIdFor">
          <p class="card-header-title">Mi Perfil</p>
          <a class="card-header-icon">
            <b-icon :icon="props.open ? 'menu-down' : 'menu-up'"> </b-icon>
          </a>
        </div>
      </template>
      <div class="card-content">
        <div class="columns">
          <div class="column">
            <h1 class="title">Nombre: {{ user.name }} {{ user.lastName }} / Rol: {{ rol }}</h1>
          </div>
        </div>
      </div>
    </b-collapse>
  </div>
</template>



<script lang="ts">
import { Component, Mixins } from "vue-property-decorator";
import { SxBuefyTableMixin } from "@/mixins";
import { User } from "@/core/model";
import axios from "axios";
import settings from "@/core/utils/app-settings";

@Component
export default class ProfileComponent extends Mixins<
  SxBuefyTableMixin<User>
>(SxBuefyTableMixin) {
  id = this.$store.state.authModule.user.id;
  user = [];
  rol: string = "Usuario";

  async created(){
    const resUsers = await axios.get(settings.API_URL + `api/User/${this.id}`);
    this.user = resUsers.data;

    if (resUsers.data.userRole === 0){
      this.rol = "Administrador";
    }
  }
}
</script>

<style scoped>
.profile{
  padding: 30px;
}
</style>