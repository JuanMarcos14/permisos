<template>
  <div>
    <b-container>
      <b-row>
        <b-col>
          <h4 class="font-weight-bold">Permisos</h4>
          <h5>Lista</h5>
        </b-col>
        <b-col>
          <br />
          <b-button v-on:click="Edit({})" size="sm" class="float-right" variant="success">
            <b-icon icon="plus"></b-icon>Agregar
          </b-button>
        </b-col>
      </b-row>
      <hr />
      <table class="table table-sm table-bordered">
        <thead>
          <tr class="table-info">
            <th>
              <b-icon icon="hash"></b-icon>
            </th>
            <th>Empleado:</th>
            <th>Tipo de permiso:</th>
            <th>Fecha:</th>
            <th>Opciones:</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(p, i) in permisos" v-bind:key="i">
            <td>{{ i + 1}}</td>
            <td>{{ p.nombreEmpleado }} {{ p.apellidosEmpleado }}</td>
            <td>{{ p.tipoPermiso }}</td>
            <td>{{ p.fecha | date }}</td>
            <td>
              <b-button v-on:click="Edit(p)" size="sm" class="linkWarning" variant="link">
                <b-icon icon="pencil"></b-icon> Editar
              </b-button>
              <b-button
                v-on:click="DeleteConfirmation(p)"
                size="sm"
                class="linkDanger"
                variant="link"
              >
                <b-icon icon="x"></b-icon> Eliminar
              </b-button>
            </td>
          </tr>
        </tbody>
      </table>
      <PermisoForm :permiso="selectedPermiso" />

      <b-modal id="deletePermisoModal" hide-footer
        :header-bg-variant="'danger'"
        :header-text-variant="'light'">
        <template v-slot:modal-title>
          ¿Seguro que desea eliminar el permiso no. {{ selectedPermiso.id }} 
          del empleado {{ selectedPermiso.nombreEmpleado }} {{ selectedPermiso.apellidosEmpleado }}?
        </template>
        <b-button variant="light" @click="$bvModal.hide('deletePermisoModal')">Cancelar</b-button> &nbsp; 
        <b-button variant="danger" v-on:click="Delete" @click="$bvModal.hide('deletePermisoModal')">Eliminar</b-button>
      </b-modal>
    </b-container>
  </div>
</template>

<script>
import PermisoForm from "./PermisoForm.vue";
import axios from "axios";

export default {
  name: "Permisos",
  components: {
    PermisoForm,
  },
  data: function () {
    return {
      permisos: [],
      selectedPermiso: {},
      BaseUrl: "http://localhost:54614/",
    };
  },
  created() {
    this.CargarPermisos();
  },
  methods: {
    Edit: function (obj) {
      this.selectedPermiso = obj;
      this.selectedPermiso.fecha = new Date(this.selectedPermiso.fecha);
      this.$bvModal.show("permisoFormModal");
    },

    CargarPermisos: function () {
      axios.get(this.BaseUrl + "api/permisos").then((response) => {
        this.permisos = response.data;
      });
    },

    Delete: function() {
        axios.delete(this.BaseUrl + "api/permisos/" + this.selectedPermiso.id).then(() => {
            this.$bvModal.hide("deletePermisoModal");
            this.CargarPermisos();
        });
    },

    DeleteConfirmation: function (obj) {
      this.selectedPermiso = obj;
      this.$bvModal.show("deletePermisoModal");
    },
  },
  mounted() {
    this.$root.$on("bv::modal::hide", () => {
      this.CargarPermisos();
    });
  },
};
</script>

<style scoped>
.linkWarning {
  color: #daa404 !important;
}

.linkDanger {
  color: #b60c0c !important;
}
</style>