@echo off
REM =====================================================
REM Configuracoes do projeto
REM =====================================================

set SOLUTION_PATH=C:\Users\leom\MottuFlowDotNet\MottuFlowDotNet.sln
set PROJECT_KEY=MottuFlowDotNet
set ORG_KEY=leomotalima
set SONAR_TOKEN=b6654c8e5ae4aef33f9ff2f596b1de88091bff13

REM =====================================================
REM Executar analise SonarCloud
REM =====================================================

echo Iniciando analise SonarCloud...
dotnet sonarscanner begin /k:"%PROJECT_KEY%" /o:"%ORG_KEY%" /d:sonar.login="%SONAR_TOKEN%"

echo Compilando projeto...
dotnet build "%SOLUTION_PATH%"

echo Finalizando analise...
dotnet sonarscanner end /d:sonar.login="%SONAR_TOKEN%"

echo Analise concluida! Verifique os resultados no SonarCloud.
pause
