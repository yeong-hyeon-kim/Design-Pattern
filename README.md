# 📕 Design Pattern

> 디자인 패턴 코드를 작성하면서 알아봅니다.

## 🏷️ 디자인 패턴(Design Pattern)

- [생성(Creational)](#생성(Creational))
  - [싱글턴(Singleton)](#싱글턴(Singleton))
  - [팩토리 메서드(Factory Methods)](#팩토리-메서드(Factory-Methods))
  - [빌더(Builder)](#빌더(Builder))
  - [프로토타입(Prototype)](#프로토타입(Prototype))
- [구조(Structural)](#기능)
- [행위(Behavioral)](#기능)

## 💡 사용 예제(Usage Example)

### 생성(Creational)

- __객체 생성__ 에 관련된 패턴입니다.
- 객체 생성을 보다 효율적이고 확장성 있게 할 수 있는 방법을 고안합니다.
- 최소한의 객체를 생성하는데 초점을 둡니다.

#### 싱글턴(Singleton)

- 실행하는 동안 객체 하나만 생성하고 접근하기 때문에 접근, 수정이 편리합니다.
- 모든 데이터를 전역으로 관리하여 쉽게 접근할 수 있습니다.

#### 팩토리 메서드(Factory Methods)

- 객체를 생성할때 인스턴스(Instance)의 타입(Type)을 서브 클래스가 결정하도록 위임합니다.
    > 인터페이스와 동일한 역할

##### 팩토리 메서드(Factory Methods) 구성요소

- Product : 가장 기본이 되는 타입, 일반화 시킬 수 있는 가장 큰 분류
  - Ex. 자동차, 동물, 식물
- ConcreteProduct - Product를 상속 받는 클래스
  - Ex. 자동차 > 아반떼, 쏘나타
  - Ex. 동물 > 사자, 호랑이, 고양이
  - Ex. 식물 > 양배추, 양상추
- Creator - Product를 생성하는 메서드가 있는 클래스
- ConcreteCreator - Creator를 상속 받아 ConcreteProduct를 구현하는 메서드가 있는 클래스

#### 빌더(Builder)

- 생성자의 가독성과 매개변수 수정 용이성 및 인자 불일치 방지를 위한 패턴입니다.
- 빌더(Builder)를 이용하여 생성자를 직관적으로 초기화 할 수 있도록 합니다.

#### 프로토타입(Prototype)

- 매계 변수로 타입을 받아 기존에 생성된 객체를 이용하여 해당 타입의 객체를 생성합니다.
- Clone을 이용하여 객체를 생성합니다.

## 💻 개발 환경(Develop Environment)

### 시스템 환경(System Environment)

||운영체제(OS)|언어(Language)|프레임워크(Framework)|종속성(Dependency)|
|-|:-:|:-:|:-:|:-:|
|명칭(Name)|![Windows](https://img.shields.io/badge/Windows-0078D6?style=flat-square&logo=Windows&logoColor=white)|![CSHARP](https://img.shields.io/badge/CSHARP-239120?style=flat-square&logo=CSharp&logoColor=white)|![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat-square&logo=.NET&logoColor=white)|![NuGet](https://img.shields.io/badge/NUGET-004880?style=flat-square&logo=NuGet&logoColor=white)|
|버전(Version)|`10, 11`|`10.0`|`6.0`|`-`|

## 🔍 정보(Information)

### 🖋️ 저자(Author)

- yeong-hyeon-kim – codechemi@gmail.com

### ⚖️ 라이센스(License)

다음 라이센스를 준수하며 [License](./License)에서 자세한 정보를 확인할 수 있습니다.

## 📖 비고(Remark)
