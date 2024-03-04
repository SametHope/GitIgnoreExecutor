# GitIgnoreExecutor - .gitignore Uygulayıcı
 See [English TLDR](https://github.com/SametHope/GitIgnoreExecutor/edit/main/README.md#english-tldr) below for English.  

 Sağlanan .gitignore kurallarınca belirtilen dizini git ihtiyacı olmadan temizleyen bir yazılım.  

 Bu program seçili bir dizinde, seçilen .gitignore kurallarınca görmezden gelinmesi planlanan dosya ve dizinleri silip, projeyi sanki bir depodan yeni klonlanmış gibi temiz hale getirir.

 Programın çalışması için sistemde git versiyon kontrol sisteminin yüklü olmasına ve hatta temizlenecek proje için bit git deposu oluşturulmuş olmasına dahi gerek yok. 
 Proje dosyalarının ve temizlik için kullanılacak .gitignore kurallarının sağlanması yeterli. 
 
 ## Kullanım

 1. Programı açınız.
![2024-03-04 19_19_46-Window](https://github.com/SametHope/GitIgnoreExecutor/assets/85421686/3019c94e-404c-4663-a6a7-0871aaede7ba)

 2. Hedef kurallarınızı ve dizininizi seçip kutucuğu işaretleyiniz. Çalıştır butonunun aktifleştiğini göreceksiniz.
![2024-03-04 19_25_57-Window](https://github.com/SametHope/GitIgnoreExecutor/assets/85421686/ffe4d6f8-d998-4f61-9933-710f0e26bd16)

 3. Çalıştır butonuna basıp çıkan diyalogta tamama basınız.
![2024-03-04 19_26_28-Window](https://github.com/SametHope/GitIgnoreExecutor/assets/85421686/a1ccc1d1-d803-418e-9e4a-86e52c6cf2b6)

 4. Uyarıyı dikkate alıp seçilen dizin ve .gitignore kurallarından emin olduktan sonra evete basıp devam ediniz.
![2024-03-04 19_31_19-Window](https://github.com/SametHope/GitIgnoreExecutor/assets/85421686/b9e97994-fbfb-46b5-aea8-8f6228e9d95b)   

 5. Bu bilgi mesajını aldıktan sonra programı kapatabilirsiniz.
![2024-03-04 19_31_30-Window](https://github.com/SametHope/GitIgnoreExecutor/assets/85421686/c79f37e2-8846-4b19-accd-4f218dfc65a8)   

## English TLDR
This is a software to cleanse files and directories from a directory according to a given .gitignore ruleset.  

When run on a directory with a given ruleset, program deletes all file and folders that would have been ignored by git version control system, making the project as clena as if it had just been just cloned from the repository.  

This is pretty useful as it does not require git to be installed on the system or even a repository to exist to clean projects from junk files.

This software is made using .Net Framework as it is used in our curriculum at the University.

Special thanks to [MAB.DotIgnore](https://github.com/markashleybell/MAB.DotIgnore) package for providing the necessary API for this project to work with ease.
