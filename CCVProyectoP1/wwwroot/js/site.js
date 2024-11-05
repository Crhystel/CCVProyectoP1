function cargarProfesoresPorClase() {
    var claseSeleccionada = document.getElementById("ClaseSelect").value;
    var profesorSelect = document.getElementById("ProfesorSelect");

    if (claseSeleccionada) {
        fetch(`/Profesores/ObtenerPorClase?clase=${claseSeleccionada}`)
            .then(response => response.json())
            .then(profesores => {
                // Limpia las opciones previas
                profesorSelect.innerHTML = '<option value="">Seleccione un profesor</option>';
                profesores.forEach(profesor => {
                    var option = document.createElement("option");
                    option.value = profesor.id;
                    option.textContent = profesor.nombre;
                    profesorSelect.appendChild(option);
                });
            })
            .catch(error => console.error('Error al cargar los profesores:', error));
    } else {
        // Si no hay clase seleccionada, resetea el dropdown de profesores
        profesorSelect.innerHTML = '<option value="">Seleccione un profesor</option>';
    }
}
function cargarEstudiantesPorGrado() {
    var gradoSeleccionado = document.getElementById("GradoSelect").value;
    var estduianteSelect = document.getElementById("EstudianteSelect");
    if (gradoSeleccionado) {
        fetch(`/Estudiantes/ObtenerPorGrado?grado=${gradoSeleccionado}`)
            .then(response => response.json())
            .then(estudiantes => {
                estduianteSelect.innerHTML = '<option value="">Seleccione un Estudiante</option>';
                estudiantes.forEach(estudiantes => {
                    var option = document.createElement("option");
                    option.value = estudiantes.id;
                    option.textContent = estudiantes.nombre;
                    estduianteSelect.appendChild(option);
                });
            })
            .catch(error => console.error('Error al cargar estudiantes:', error));
    } else {
        estduianteSelect.innerHTML = '<option value="">Seleccione un Estudiante</option>';
    }
}