var app = angular.module('myApp', []);

app.controller('loteriaController', function ($scope, $http, $sce, $element)
{
    $scope.ListaSelecionados = [];

    $scope.SelecionarNumero = function (numero, totalMaximoSelecionados)
    {
        var estaNaLista = $scope.NumeroJaExiste(numero);
        if (!estaNaLista)
        {
            if ($scope.ListaSelecionados.length < totalMaximoSelecionados)
            {
                $scope.ListaSelecionados.push(numero);
            }
        }
        else
        {
            $scope.ListaSelecionados.splice($scope.ListaSelecionados.indexOf(numero), 1);
        }
    }

    $scope.NumeroJaExiste = function (numero)
    {
        var estaNaLista = $scope.ListaSelecionados.some(function (item) {
            return item === numero;
        });

        return estaNaLista;
    }

    $scope.SalvarAposta = function (url, totalMaximoSelecionados)
    {
        if ($scope.ListaSelecionados.length < totalMaximoSelecionados)
        {
            alert("A aposta deve conter " + totalMaximoSelecionados + " números!");
            return;
        }

        $.ajax({
            method: 'POST',
            url: url,
            data:
            {
                numerosSelecionados: $scope.ListaSelecionados
            },
            ignoreLoadingBar: true
        })
        .success(function (response)
        {
            alert("Aposta realizada com sucesso!");
            $scope.NovaAposta();
        })
        .complete(function (response)
        {
            $scope.$apply();
        });
    }

    $scope.GerarAposta = function (url) {
        $.ajax({
            url: url,
            ignoreLoadingBar: true
        })
        .success(function (response) {
            alert("Aposta realizada com sucesso!");
            $scope.NovaAposta();
        })
        .complete(function (response) {
            $scope.$apply();
        });
    }

    $scope.NovaAposta = function ()
    {
        $scope.ListaSelecionados = [];
    }
});