# GS1 L3 Serialization & Aggregation Project

Bu proje, **Takip ve İzleme (Track & Trace)** süreçlerini simüle etmek amacıyla geliştirilmiş bir **L3 (Hat Yönetimi)** yazılımıdır.

## 🚀 Proje Özellikleri

* **Backend:** .NET 8 (ASP.NET Core Web API)
* **Veritabanı:** MS SQL Server (Entity Framework Core - Code First)
* **Frontend:** Windows Forms (Operatör Paneli)
* **Mimari:** N-Layer Architecture, Repository Pattern.
* **GS1 Standartları:**
  * **(01) GTIN:** Global Ticari Ürün Numarası
  * **(17) EXP:** Son Kullanma Tarihi
  * **(10) LOT:** Parti Numarası
  * **(21) SN:** Benzersiz Seri Numarası
  * **(00) SSCC:** Taşıma Kabı Kodu (Koli/Palet)

## 🛠️ Teknik Yetenekler & Senaryo

1.  **İş Emri (Work Order) Yönetimi:**
    * Operatör; Lot No, SKT ve Üretim Adedini belirleyerek iş emri oluşturabilir.
    * Sistem, belirtilen adet kadar benzersiz karekod üretir.

2.  **Hiyerarşik Agregasyon (Aggregation):**
    * Sistem, **"Parent-Child"** ilişkisini destekler.
    * Otomatik olarak **her 10 ürünü 1 Koliye (Case)** atar.
    * Koli için **SSCC (Serial Shipping Container Code)** üretir ve ürünleri bu koliyle veritabanında ilişkilendirir.

3.  **Simülasyon:**
    * PLC sistemi, yazılım tarafında bir simülasyon döngüsü ile taklit edilmiştir.

## ⚙️ Kurulum

1.  `appsettings.json` dosyasındaki **ConnectionString** alanını kendi SQL Server bilginize göre düzenleyin.
2.  Package Manager Console üzerinden `Update-Database` komutunu çalıştırarak veritabanını oluşturun.
3.  Önce **GS1.API**, ardından **GS1.Desktop** projesini çalıştırın.

---
*Geliştirici: Kadir Gökçe*
