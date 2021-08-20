<template>
  <div class="workshops">
    <p class="title">Mis Talleres</p>
    <div class="columns">
      <div class="column" v-for="workshop in workShops" :key="workshop.id" :value="workshop.id">
        <div class="card">
          <div class="card-content">
            <p>Taller: {{ workshop.name }} / Descripción: {{ workshop.description }} / {{ workshop.contentSupport }}</p> <br/><br/>
          </div>
        </div>

      </div>
    </div>
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
  workShops = [];

  async created(){
    const resWorkShops = await axios.get(settings.API_URL + "api/WorkShop");
    this.workShops = resWorkShops.data;
  }
}
</script>

<style scoped>
.workshops{
  padding: 30px;
}
</style>
