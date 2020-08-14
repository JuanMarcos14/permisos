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
          <b-button size="sm" class="float-right" variant="success">
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
          <tr>
            <td>1</td>
            <td>Juan Marcos Susana Feliz</td>
            <td>Asuntos familiares</td>
            <td>20/08/2020</td>
            <td>
              <b-button size="sm" class="linkWarning" variant="link">
                <b-icon icon="pencil"></b-icon> Editar
              </b-button>
              <b-button size="sm" class="linkDanger" variant="link">
                <b-icon icon="x"></b-icon> Eliminar
              </b-button>
            </td>
          </tr>
        </tbody>
      </table>
    </b-container>
  </div>
</template>

<script>
export default {
  name: "Permisos",
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