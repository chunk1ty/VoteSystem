(function () {
    'use strict';

    var getAllQuestionsUrl = $('#get-all-questionRepository-url').val();

    $.ajax({
        type: 'GET',
        url: getAllQuestionsUrl,
        contentType: 'application/json',
        success: function (questions) {
            if (questions !== {}) {
                var postTemplateHtml = document.getElementById('question-template').innerHTML;
                var postTemplate = Handlebars.compile(postTemplateHtml);
                document.getElementById('root').innerHTML = postTemplate({ questions: questions });

                for (var i = 0; i < questions.length; i++) {
                    //TODO think better way to handle results
                    var answers = [];
                    var answersAndCount = [];

                    for (var j = 0; j < questions[i].questionAnswers.length; j++) {
                        answers.push(questions[i].questionAnswers[j].questionAnswerName);
                        answersAndCount.push({
                            value: questions[i].questionAnswers[j].userAnswerCount,
                            name: questions[i].questionAnswers[j].questionAnswerName
                        })
                    }

                    var myChart = echarts.init(document.getElementById('echart-pie-' + i), theme);

                    myChart.setOption({
                        tooltip: {
                            trigger: 'item',
                            formatter: "{a} <br/>{b} : {c} ({d}%)"
                        },
                        legend: {
                            x: 'center',
                            y: 'bottom',
                            data: answers
                        },
                        toolbox: {
                            show: true,
                            feature: {
                                magicType: {
                                    show: true,
                                    type: ['pie', 'funnel'],
                                    option: {
                                        funnel: {
                                            x: '25%',
                                            width: '50%',
                                            funnelAlign: 'left',
                                            max: 1548
                                        }
                                    }
                                },
                                saveAsImage: {
                                    show: true
                                }
                            }
                        },
                        calculable: true,
                        series: [{
                            name: questions[i].questionName,
                            type: 'pie',
                            radius: '55%',
                            center: ['50%', '48%'],
                            data: answersAndCount
                        }]
                    });
                }
            }
        },
        error: function (ex) {
            alert('Can not find questions!');
        }
    });
}());