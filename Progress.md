TaskFlow — Progression du projet
✅ Fait
Setup

Projet Unity 6 créé (2D Core)
TextMeshPro importé
4 widgets importés (Accordion, ConfirmModal, SearchableDropdown, TabbedPanel)
Dossiers organisés : Prefabs/, Scripts/, TaskFlow/, TextMesh Pro/
Scène renommée MainScene

Données

MockData.cs créé dans Assets/TaskFlow/
30 tâches fictives réparties en 3 statuts (ToDo / InProgress / Done)
16 projets fictifs dans la liste

UI — Structure

Canvas principal configuré (Screen Space Overlay, 1920x1080, Scale With Screen Size)
Background panel (fond sombre #1E1E2E)
Header (60px, couleur #2D2B55) avec :

Texte "TaskFlow" (Bold, taille 28)
Bouton "Vider le projet" (rouge, branché sur OnViderClicked)



Widgets intégrés
TabbedPanel ✅

3 onglets : "Mes tâches" / "Équipe" / "Stats"
Pages : PageMesTaches / PageEquipe / PageStats
Pages branchées dans TabbedPanelController

SearchableDropdown ✅

Reconstruit manuellement dans PageMesTaches (sans double Canvas)
Structure : Button + Panel (InputField + ScrollView + Content)
Script SearchableDropdown.cs attaché avec toutes les références branchées
Bouton branché sur TogglePanel()
ItemPrefab existant réutilisé

Accordion ✅

Placé dans PageMesTaches
3 sections : "À faire" / "En cours" / "Terminé"
ContentArea de Section2 et Section3 désactivés par défaut (Section1 ouverte)
AccordionController branché avec les 3 ContentArea
Mode exclusif : une seule section ouverte à la fois

ConfirmModal ✅

Placé sous Canvas principal
Canvas component ajouté (Override Sorting, Sort Order 999)
Graphic Raycaster ajouté
Rect Transform stretch/stretch (0,0,0,0)
BtnConfirm → OnClickConfirm() ✅
BtnCancel → OnClickCancel() ✅
Désactivé par défaut

Script principal

TaskFlowController.cs créé dans Assets/TaskFlow/
GameObject vide TaskFlowController dans la scène
Toutes les références branchées :

Project Filter → SearchableDropdown
Accordion → Accordion
Confirm Modal → ConfirmModal
Todo/InProgress/Done Content → ContentArea des 3 sections
Todo/InProgress/Done Header → Text (TMP) des 3 HeaderButtons
Task Item Prefab → ItemPrefab


Filtrage par projet fonctionnel
Compteurs dynamiques dans les headers (ex: "À faire (10)")
Vider le projet fonctionnel avec confirmation


❌ Reste à faire
Fonctionnel

 Onglet Équipe — cartes membres statiques (avatar texte, nom, rôle, nb tâches)
 Onglet Stats — 3 grands chiffres (tâches actives, terminées, taux de complétion)
 SearchableDropdown — les items (projets) ne s'affichent pas encore visuellement (à tester/confirmer)

Polish UI

 Texte des tâches illisible dans l'Accordion — revoir le prefab ItemPrefab (couleur texte, taille, padding)
 Couleurs cohérentes sur tous les widgets (palette unifiée)
 Couleur du Header (actuellement trop proche du fond)
 Hover effects sur les boutons
 Espacement régulier entre les éléments
 Style des headers Accordion (couleur, texte)
 Style du SearchableDropdown (couleur du bouton, du panel)

Soutenance

 Slides de présentation
 Script démo minute par minute
 Flash de pub (à retravailler)
 Répétitions


Bugs connus / Limitations assumées

SearchableDropdown : prefab original avec double Canvas — reconstruit manuellement
TabbedPanel : pas de surlignage de l'onglet actif
ConfirmModal : pas d'overlay bloquant (corrigé partiellement avec Sort Order 999 + Graphic Raycaster)
Accordion : pas d'indicateur visuel (flèche) de l'état ouvert/fermé
SearchableDropdown : pas de message "Aucun résultat"