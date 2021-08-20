<template>
  <div>
    <p class="title">Detalles</p>
    <div class="card">
      <div class="card-content">
        <p>{{ selectedWorkShop.name }} / {{ selectedWorkShop.description }} / {{ selectedWorkShop.contentSupport }}</p> <br/>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Mixins } from "vue-property-decorator";
import { SxBuefyTableMixin } from "@/mixins";
import { BTableColumn } from "@/components/sx/sx-buefy-table/config";
import { WorkShop } from "@/core/model";
import axios from "axios";
import settings from "@/core/utils/app-settings";

@Component({

})
export default class WorkShopDetailsComponent extends Mixins<SxBuefyTableMixin<WorkShop>>(SxBuefyTableMixin) {
  currentWorkshopId: string = this.$router.currentRoute.path.substring(25)
  selectedWorkShop = [];

  async created(){
    const resWorkShops = await axios.get(settings.API_URL + `api/WorkShop/${this.currentWorkshopId}`);
    this.selectedWorkShop = resWorkShops.data;
  }
}
</script>