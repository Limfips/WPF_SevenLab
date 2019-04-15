# О проекте
Запрос на поиск фирм:
```python
if ((~propertiesCandidate & firm.GetUndesirableProperties()) == firm.GetUndesirableProperties() &&
                    (firm.GetDesiredProperties() & propertiesCandidate) == firm.GetDesiredProperties())
```
* <a href="WPF_SevenLab/WPF_SevenLab/CandidatesAndFirms/Firms.cs">Просмотреть/</a>
Запрос на поиск работников:
```python
if ((desiredProperties & candidate.GetPropertiesCandidate()) == desiredProperties &&
                    (propertiesFirm & candidate.GetPropertiesFirm()) == candidate.GetPropertiesFirm() &&
                    (~candidate.GetPropertiesCandidate() & undesirableProperties) == undesirableProperties)
```
* <a href="WPF_SevenLab/WPF_SevenLab/CandidatesAndFirms/CandidatesClass.cs">Просмотреть/</a>
## Google
[Google](https://www.google.ru/?hl=ru)