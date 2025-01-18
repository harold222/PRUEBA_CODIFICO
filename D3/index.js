(() => {
  const setMargin = 20;
  const availableColors = ['#ff6084', '#37c2eb', '#bbce56', '#4bc0c0', '#0066ff'];
  const validPattern = /^[0-9.,]*$/;

  document.addEventListener('DOMContentLoaded', () => {
    const button = document.getElementById('update-button');
    const input = document.getElementById('data-input');

    if (!button || !input) return alert('No se encontró elementos en el HTML');

    input.addEventListener('input', (e) => {
      const text = e.target.value;

      if (!validPattern.test(text))
        e.target.value = text.slice(0, -1);
    });

    // Detectar el enter del input para que se ejecute el click del botón
    input.addEventListener('keypress', (e) => {
      if (e.key === 'Enter') button.click();
    });

    button.addEventListener('click', () => {
      const chart = d3.select('#chart');
      chart.selectAll('*').remove();

      const text = document.getElementById('data-input');
      if (!text) return alert('No se encontró el input de texto');
      
      const inputData = text.value;
      if (!inputData) return alert('No se ingresó ningún dato');

      if (!validPattern.test(inputData)) return alert("Solo se permiten números positivos, decimales y comas");

      const data = inputData.split(',').map(d => parseFloat(d.trim())).filter(d => !isNaN(d));

      const margin = 
        { top: setMargin, right: setMargin, bottom: setMargin, left: setMargin },
        width = 600 - margin.left - margin.right,
        height = 500 - margin.top - margin.bottom;

      // Crear SVG
      const svg = chart
                    .append('svg')
                    .attr('width', width + margin.left + margin.right)
                    .attr('height', height + margin.top + margin.bottom)
                    .append('g')
                    .attr('transform', `translate(${margin.left},${margin.top})`);

      const x = d3.scaleLinear()
        .domain([0, d3.max(data)])
        .range([0, width]);

      const y = d3.scaleBand()
        .domain(data.map((_, i) => i))
        .range([0, height])
        .padding(0.1);

      // Crear barras
      svg.selectAll('.bar')
          .data(data)
          .enter()
          .append('rect')
          .attr('class', 'bar')
          .attr('x', 0)
          .attr('y', (d, i) => y(i)) 
          .attr('width', d => x(d))
          .attr('height', y.bandwidth())
          .attr('fill', (d, i) => availableColors[i % availableColors.length]);

      // Crear texto
      svg.selectAll('.text')
            .data(data)
            .enter()
            .append('text')
            .attr('class', 'text')
            .attr('x', d => x(d) - 5)
            .attr('y', (d, i) => y(i) + y.bandwidth() / 2)
            .attr('dy', '.35em')
            .attr('text-anchor', 'end')
            .attr('fill', 'white')
            .text(d => d);
    });
  });
})();