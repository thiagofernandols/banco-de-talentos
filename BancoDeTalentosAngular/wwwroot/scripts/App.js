var app = angular.module("talentosApp", []);

app.controller("talentosCtrl", function ($scope, $http) {

    $scope.model = {};

    $scope.DadosControle = {
        isInsert: false, isEdicao: false, btnNome: "Adicionar Talento",
        btnAdd: "Próximo", aba: 1, aba2: true, aba3: true
    };

    $scope.GetTalentos = function () {
        $http({
            method: 'GET',
            url: '/home/GetTalentos/'
        }).then(function successCallback(response) {
            $scope.listaTalentos = response.data;
        }, function errorCallback(response) {
            console.log(response);
        });
    }
    $scope.GetTalentos();
    $http({
        method: 'GET',
        url: '/home/GetDisponibilidade/'
    }).then(function successCallback(response) {
        $scope.listaDisponibilidade = response.data;
    }, function errorCallback(response) {
        console.log(response);
    });

    $http({
        method: 'GET',
        url: '/home/GetMelhorHorario/'
    }).then(function successCallback(response) {
        $scope.listaMelhorHorario = response.data;
    }, function errorCallback(response) {
        console.log(response);
    });

    $scope.GetConhecimentoEspecifico = function () {
        $http({
            method: 'GET',
            url: '/home/GetConhecimentoEspecifico/'
        }).then(function successCallback(response) {
            $scope.ListaConhecimentosEsp = response.data;
        }, function errorCallback(response) {
            console.log(response);
        });
    }
    $scope.GetConhecimentoEspecifico();
    $scope.Addtalento = function (talento) {
        if ($scope.DadosControle.isInsert && $(".cadastro").find(".ng-invalid").length > 0) {
            return;
        }
        if ($scope.DadosControle.aba == 1) {
            $scope.DadosControle.aba = 2;
            $scope.DadosControle.aba2 = false;
            $("#aba2").click();
            return;
        }
        else if ($scope.DadosControle.aba == 2) {
            $scope.DadosControle.aba = 3;
            $scope.DadosControle.aba3 = false;
            $("#aba3").click();
            $scope.DadosControle.btnAdd = "Salvar";
            return;
        }
        $scope.Salvar(talento);
    }

    $scope.Salvar = function (talento) {

        var objeto = {
            Nome: talento.Nome,
            Email: talento.Email,
            Nome: talento.Nome,
            Skype: talento.Skype,
            Whatsapp: talento.Whatsapp,
            Linkedin: talento.Linkedin,
            Cidade: talento.Cidade,
            Estado: talento.Estado,
            Portfolio: talento.Portfolio,
            Pretensao: talento.Pretensao,
            LinkCrud: talento.LinkCrud,
            TalentoDisponibilidade: [],
            TalentoMelhorHorario: [],
            TalentoConhecimentos: [],
            InfoBancaria: []
        };
        for (var i in talento.TalentoDisponibilidade) {
            objeto.TalentoDisponibilidade.push({ idTalento: talento.IdTalento, idDisponibilidade: talento.TalentoDisponibilidade[i] });
        }

        for (var i in talento.TalentoMelhorHorario) {
            objeto.TalentoMelhorHorario.push({ idTalento: talento.IdTalento, idMelhorHorario: talento.TalentoMelhorHorario[i] });
        }
        if (talento.InfoBancaria) {
            var tipoConta;
            if (talento.InfoBancaria.TipoContaCorrente && !talento.InfoBancaria.TipoContaPoupanca)
                tipoConta = "C";
            else if (!talento.InfoBancaria.TipoContaCorrente && talento.InfoBancaria.TipoContaPoupanca)
                tipoConta = "P";
            else if (talento.InfoBancaria.TipoContaCorrente && talento.InfoBancaria.TipoContaPoupanca)
                tipoConta = "C,P";
            if ($scope.DadosControle.isInsert) {
                objeto.InfoBancaria.push({
                    Nome: talento.InfoBancaria.Nome, Cpf: talento.InfoBancaria.Cpf, Banco: talento.InfoBancaria.Banco, Agencia: talento.InfoBancaria.Agencia,
                    TipoConta: tipoConta, NumeroConta: talento.InfoBancaria.NumeroConta
                });
            } else {
                objeto.InfoBancaria.push({
                    IdTalento: talento.IdTalento, IdInfoBancaria: talento.InfoBancaria.IdInfoBancaria, Nome: talento.InfoBancaria.Nome, Cpf: talento.InfoBancaria.Cpf, Banco: talento.InfoBancaria.Banco, Agencia: talento.InfoBancaria.Agencia,
                    TipoConta: tipoConta, NumeroConta: talento.InfoBancaria.NumeroConta
                });
            }
        }
        for (var i in $scope.ListaConhecimentosEsp) {
            if ($scope.ListaConhecimentosEsp[i].avaliacao)
                objeto.TalentoConhecimentos.push({ idTalentoConhecimentos: $scope.ListaConhecimentosEsp[i].idTalentoConhecimentos, idTalento: talento.IdTalento, idConhecimentoEspecifico: $scope.ListaConhecimentosEsp[i].idConhecimentoEspecifico, Avaliacao: $scope.ListaConhecimentosEsp[i].avaliacao });
        }
        var _url = '/home/IncluirTalento/';
        if (!$scope.DadosControle.isInsert) {
            _url = '/home/AlterarTalento/';
            objeto.IdTalento = talento.IdTalento;
        }
        $http({
            method: 'POST',
            url: _url,
            data: JSON.stringify(objeto)
        }).then(function successCallback(response) {
            ExibeMensagem("Incluído com sucesso", "SUCESSO");
            $scope.listaTalentos = response.data;
            $scope.DadosControle.isInsert = false;
            $scope.DadosControle.isEdicao = false;
            $scope.DadosControle.btnAdd = "Próximo";
            $scope.DadosControle.aba = 1;
            $scope.DadosControle.aba2 = true;
            $scope.DadosControle.aba3 = true;
            $scope.model = {};
        }, function errorCallback(response) {
            console.log(response);
        });
    }
    $scope.Deletartalento = function (objeto) {
        $http({
            method: 'POST',
            url: '/home/ExcluirTalento/',
            data: JSON.stringify(objeto)
        }).then(function successCallback(response) {
            ExibeMensagem("Excluído com sucesso", "SUCESSO");
            $scope.listaTalentos = response.data;
        }, function errorCallback(response) {
            console.log(response);
        });
    }

    $scope.NovoTalento = function () {
        $scope.GetConhecimentoEspecifico();
        $scope.DadosControle.isInsert = true;
        $scope.DadosControle.isEdicao = true;
    };

    $scope.Cancelar = function () {
        $scope.DadosControle.isInsert = false;
        $scope.DadosControle.isEdicao = false;
        $scope.DadosControle.aba2 = true;
        $scope.DadosControle.aba3 = true;
        $scope.DadosControle.aba = 1;
        $scope.DadosControle.btnAdd = "Próximo";
        $scope.model = {};
    };

    $scope.Editartalento = function (talento) {
        $http({
            method: 'POST',
            url: '/home/GetTalento/',
            data: JSON.stringify(talento)
        }).then(function successCallback(response) {
            $scope.model = {
                IdTalento: response.data.idTalento,
                Nome: response.data.nome,
                Email: response.data.email,
                Nome: response.data.nome,
                Skype: response.data.skype,
                Whatsapp: response.data.whatsapp,
                Linkedin: response.data.linkedin,
                Cidade: response.data.cidade,
                Estado: response.data.estado,
                Portfolio: response.data.portfolio,
                Pretensao: response.data.pretensao,
                LinkCrud: response.data.linkCrud,
                TalentoDisponibilidade: [],
                TalentoMelhorHorario: [],
                TalentoConhecimentos: [],
                InfoBancaria: []
            }
            $scope.GetTalentoDisponibilidade(response.data);
            $scope.GetTalentoMelhorHorario(response.data);
            $scope.GetTalentoConhecimentos(response.data);
            $scope.GetInfoBancaria(response.data);

            $scope.DadosControle.isInsert = false;
            $scope.DadosControle.isEdicao = true;
        }, function errorCallback(response) {
            console.log(response);
        });
    };
    $scope.GetTalentoDisponibilidade = function (talento) {
        $http({
            method: 'POST',
            url: '/home/GetTalentoDisponibilidade/',
            data: JSON.stringify(talento)
        }).then(function successCallback(response) {
            for (var i in response.data) {
                $scope.model.TalentoDisponibilidade.push(response.data[i].idDisponibilidade);
            }
        }, function errorCallback(response) {
            console.log(response);
        });
    };
    $scope.GetTalentoMelhorHorario = function (talento) {
        $http({
            method: 'POST',
            url: '/home/GetTalentoMelhorHorario/',
            data: JSON.stringify(talento)
        }).then(function successCallback(response) {
            for (var i in response.data) {
                $scope.model.TalentoMelhorHorario.push(response.data[i].idMelhorHorario);
            }
        }, function errorCallback(response) {
            console.log(response);
        });
    };
    $scope.GetTalentoConhecimentos = function (talento) {
        $http({
            method: 'POST',
            url: '/home/GetTalentoConhecimentos/',
            data: JSON.stringify(talento)
        }).then(function successCallback(response) {
            for (var i in response.data) {
                for (var j in $scope.ListaConhecimentosEsp) {
                    if (response.data[i].idConhecimentoEspecifico == $scope.ListaConhecimentosEsp[j].idConhecimentoEspecifico)
                        $scope.ListaConhecimentosEsp[j].avaliacao = String(response.data[i].avaliacao);
                }
            }
        }, function errorCallback(response) {
            console.log(response);
        });
    };
    $scope.GetInfoBancaria = function (talento) {
        $http({
            method: 'POST',
            url: '/home/GetInfoBancaria/',
            data: JSON.stringify(talento)
        }).then(function successCallback(response) {
            for (var i in response.data) {
                $scope.model.InfoBancaria.IdInfoBancaria = response.data[i].idInfoBancaria;
                $scope.model.InfoBancaria.Nome = response.data[i].nome;
                $scope.model.InfoBancaria.Banco = response.data[i].banco;
                $scope.model.InfoBancaria.Agencia = response.data[i].agencia;
                $scope.model.InfoBancaria.Cpf = response.data[i].cpf;
                
                if (response.data[i].tipoConta == "C")
                    $scope.model.InfoBancaria.TipoContaCorrente = true;
                else if (response.data[i].tipoConta == "P")
                    $scope.model.InfoBancaria.TipoContaPoupanca = true;
                else if (response.data[i].tipoConta == "C,P"){
                    $scope.model.InfoBancaria.TipoContaCorrente = true;
                    $scope.model.InfoBancaria.TipoContaPoupanca = true;
                }

                $scope.model.InfoBancaria.NumeroConta = response.data[i].numeroConta;
            }
        }, function errorCallback(response) {
            console.log(response);
        });
    };
});

function comboSelect2($timeout) {
    return {
        link: function (scope, element) {

            $timeout(function () {
                $(element).select2();

            }, 600)
        }
    }
};
app.directive('comboSelect2', comboSelect2);