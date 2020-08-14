<template>
  <div>
    <b-modal
      id="permisoFormModal"
      hide-footer
      :header-bg-variant="'info'"
      :header-text-variant="'light'"
      size="lg"
    >
      <template v-slot:modal-title>
        <b-icon icon="card-list"></b-icon>Permiso
      </template>
      <div class="d-block">
        <b-row>
          <b-col>
            <label>Nombres:</label>
            <b-input v-model="permiso.nombreEmpleado" size="sm"></b-input>
          </b-col>
          <b-col>
            <label>Apellidos:</label>
            <b-input v-model="permiso.apellidosEmpleado" size="sm"></b-input>
          </b-col>
        </b-row>
        <br />
        <b-row>
          <b-col>
            <label>Fecha:</label>
            <b-form-datepicker v-model="permiso.fecha" size="sm" type="date"></b-form-datepicker>
          </b-col>
          <b-col>
            <label>Tipo de permiso:</label>
            <b-form-select v-model="permiso.tipoPermisoId" :options="TiposPermisosItems" size="sm"></b-form-select>
          </b-col>
        </b-row>
        <br />
        <b-button class="float-right" v-on:click="Save()" variant="success" size="sm">
          <b-icon icon="file-earmark-check"></b-icon>Guardar
        </b-button>
      </div>
    </b-modal>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "PermisoForm",
  props: {
    permiso: {},
  },
  data: function () {
    return {
      BaseUrl: "http://localhost:54614/",
      TiposPermisosItems: [],
    };
  },
  created() {
    axios.get(this.BaseUrl + "api/tipospermisos").then((response) => {
      this.TiposPermisosItems = response.data;
    });
  },
  methods: {
    Validar: function () {
      let success = true;

      if (!this.permiso.nombreEmpleado) {
        this.$bvToast.toast("El nombre del empleado es requerido", {
          title: "Atención",
          variant: "warning",
          solid: true,
        });
        success = false;
      }

      if (!this.permiso.apellidosEmpleado) {
        this.$bvToast.toast("Los apellidos del empleado son requeridos", {
          title: "Atención",
          variant: "warning",
          solid: true,
        });

        success = false;
      }

      if (!this.permiso.fecha) {
        this.$bvToast.toast("La fecha es requerida", {
          title: "Atención",
          variant: "warning",
          solid: true,
        });

        success = false;
      }

      if (!this.permiso.tipoPermisoId) {
        this.$bvToast.toast("El tipo de permiso es requerido", {
          title: "Atención",
          variant: "warning",
          solid: true,
        });

        success = false;
      }

      return success;
    },

    Save: function () {
      if (this.Validar()) {
        this.permiso.tipoPermiso = null;
        axios.post(this.BaseUrl + "api/permisos", this.permiso).then(() => {
          this.$bvModal.hide("permisoFormModal");
        });
      }
    },
  },
};
</script>

<style scoped>
label {
  font-weight: 600;
}
</style>