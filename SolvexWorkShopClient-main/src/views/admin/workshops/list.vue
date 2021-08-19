<template>
  <div>
    <sx-buefy-table :config="tableConfig">

      <template v-slot:name="{ row }">
        <div class="media">

          <div class="media-left">
            <p class="icon-image-rounded has-background-primary">W</p>
          </div>

          <div class="media-content">
            <p class="title is-6">
              <b-tooltip label="WorkShop no disponible">
                <a class="has-text-link cursor-ban">{{ row.name }}</a>
              </b-tooltip>
            </p>
            <p class="subtitle is-6">@{{ row.name }}</p>
          </div>
        </div>
      </template>

      <template v-slot:description="{ row }">
        <p class="subtitle is-6">
          {{ row.description | description(row.description) }}
        </p>
      </template>

      <template v-slot:contentSupport="{ row }">
        <p class="subtitle is-6">
          {{ row.contentSupport | contentSupport(row.contentSupport) }}
        </p>
      </template>

    </sx-buefy-table>
  </div>
</template>

<script lang="ts">
import { Component, Mixins } from "vue-property-decorator";
import { SxBuefyTableMixin } from "@/mixins";
import { BTableColumn } from "@/components/sx/sx-buefy-table/config";
import { WorkShop } from "@/core/model";

@Component
export default class WorkShopListComponent extends Mixins<SxBuefyTableMixin<WorkShop>>(SxBuefyTableMixin) {
  created() {
    this.setTableConfig();
    this.formatColumns();
  }
  setTableConfig() {
    this.tableConfig.controller = "WorkShop";
    this.tableConfig.aggregatable = true;
    this.tableConfig.aggregating.title = "Listado de WorkShops";
  }
  formatColumns() {
    let name = new BTableColumn("name", "WorkShop");
    name.sortable = false;
    name.customTemplate = true;

    let description = new BTableColumn("description", "Descripción");
    description.sortable = false;
    description.customTemplate = true;

    let contentSupport = new BTableColumn("contentSupport", "Contenido de apoyo");
    contentSupport.customTemplate = true;
    contentSupport.sortable = false;

    this.tableConfig.insertColumns(name, description, contentSupport);
  }
}
</script>
