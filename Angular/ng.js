var app = angular.module('beun', []);
app.controller('emyoCtrl', function ($scope, $http) {
    $scope.guncellenecekkullaniciid = -1;
    $scope.ykullaniciadsoyad = "";
    $http.get("http://localhost:1513/api/Satis/TumSatislariGetir").then(function (response) {
        $scope.satislar = response.data;
    });
    $http.get("http://localhost:1513/api/Kullanici/TumKullanicilariGetir").then(function (response) {
        $scope.kullanicilar = response.data;
    });
    $http.get("http://localhost:1513/api/Urun/TumUrunleriGetir").then(function (response) {
        $scope.urunler = response.data;
    });

    $scope.kullaniciekle = function (kadsoyad) {
        $http.get("http://localhost:1513/api/Kullanici/KullaniciEkle?adsoyad=" + kadsoyad).then(function (response) {
            $scope.ykullaniciadsoyad = "";
            if (response.data == null)
                alert("Kayıt sırasında hata oluştu");
            else
                $scope.kullanicilar = response.data;
        });
    }
    $scope.urunekle = function (yeniurun) {
        $http.post("http://localhost:1513/api/Urun/UrunEkle", yeniurun).then(function (response) {
            $scope.urun = {};
            if (response.data == true) {
                $http.get("http://localhost:1513/api/Urun/TumUrunleriGetir").then(function (response) {
                    $scope.urunler = response.data;
                });
            }
            else
                alert("Ekleme işlemi sırasında hata oluştu");
        });
    }
    $scope.satisekle = function (satisverisi) {
        $http.post("http://localhost:1513/api/Satis/SatisEkle", satisverisi).then(function (response) {
            $scope.satis = {};
            if (response.data == null)
                alert("Ekleme işlemi sırasında hata oluştu");
            else {
                $scope.satislar = response.data;
                $http.get("http://localhost:1513/api/Urun/TumUrunleriGetir").then(function (response) {
                    $scope.urunler = response.data;
                });
            }
        });
    }
    $scope.kullanicisil = function (kullaniciid) {
        $http.get("http://localhost:1513/api/Kullanici/KullaniciSil?kullaniciid=" + kullaniciid).then(function (response) {
            $scope.kullanicilar = response.data;
        });
    }
    $scope.urunsil = function (UrunID) {
        $http.get("http://localhost:1513/api/Urun/UrunSil?UrunID=" + UrunID).then(function (response) {
            if (response.data == null)
                alert("urun silme işleminde hata oluştu");
            else {
                $scope.urunler = response.data;
                $http.get("http://localhost:1513/api/Satis/TumSatislariGetir").then(function (response) {
                    $scope.satislar = response.data;
                });
            }
        });
    }
    $scope.satissil = function (SatisID) {
        $http.get("http://localhost:1513/api/Satis/SatisSil?SatisID=" + SatisID).then(function (response) {
            if (response.data == null)
                alert("urun silme işleminde hata oluştu");
            else {
                $scope.satislar = response.data;
                $http.get("http://localhost:1513/api/Urun/TumUrunleriGetir").then(function (response) {
                    $scope.urunler = response.data;
                });
            }
        });
    }
    $scope.kullaniciguncellemeverilerinidoldur = function (kullanicibilgileri) {
        $scope.guncellenecekkullaniciid = kullanicibilgileri.KullaniciID;
        $scope.ykullaniciadsoyad = kullanicibilgileri.AdSoyad;
    }

    $scope.kullaniciyiguncelle = function (id, adsoyad) {
        $http.get("http://localhost:1513/api/Kullanici/KullaniciGuncelle?guncellenecekid=" + id + "&yeniadsoyad=" + adsoyad).then(function (response) {
            $scope.kullanicilar = response.data;
            $scope.guncellenecekkullaniciid = -1;
            $scope.ykullaniciadsoyad = "";
        });
    }

});