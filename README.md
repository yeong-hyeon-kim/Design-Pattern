# 📕 Design Pattern

> 디자인 패턴 코드를 작성하면서 알아봅니다.

## 🏷️ 디자인 패턴(Design Pattern)

- [생성(Creational)](#생성(Creational))
  - [싱글턴(Singleton)](#싱글턴(Singleton))
  - [팩토리 메서드(Factory Methods)](#팩토리-메서드(Factory-Methods))
  - [빌더(Builder)](#빌더(Builder))
  - [프로토타입(Prototype)](#프로토타입(Prototype))
- [구조(Structural)](#구조(Structural))
  - [어댑터(Adapter)](#어댑터(Adapter))
  - [컴포지트(Composite)](#컴포지트(Composite))
  - [데코레이터(Decorator)](#데코레이터(Decorator))
  - [퍼사드(Facade)](#퍼사드(Facade))
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

### 구조(Structural)

- __객체 합성(타입 일치)__ 에 관련된 패턴 입니다.
- 클래스나 객체를 조합해 더 큰 구조를 만드는 패턴 입니다.
- 서로 다른 타입을 같은 타입처럼 만들어 사용하는 방법에 초점을 둡니다.

#### 어댑터(Adapter)

- 인터페이스 호환성 문제(Type이 다른) 때문에 같이 쓸 수 없는 클래스들을 연결해서 사용할 수 있게 만드는 것이 목적입니다.

#### 컴포지트(Composite)

- 객체를 묶어 하나의 객체로 이용할 수 있습니다.
- 컴포넌트(Component)들을 합쳐놓은 것을 컴포지트(Composite)라 합니다.
- 각각의 클래스(컴포넌트)들 합쳐놓은 클래스(컴포지트)에서 모든 클래스를 관리할 수 있습니다.
- 컴포지트(Composite)는 클래스 계층(Hierarchy)화라고 할 수 있습니다.

#### 데코레이터(Decorator)

- 내부를 수정하지 않고 기능 확장이 필요할 때 사용합니다.
- 데코레이션(Decoration)
  - 피자에 토핑을 첨가(추가)하는 것을 의미합니다.
  - > 메서드(피자)에 기능(토핑)을 추가하는 것을 의미합니다.
- 데코레이터 카페점
  - 커피 원두에 우유를 첨가하고 모카를 첨가하니 모카라떼.
  - Ex. 커피 원두 + 우유 + 모카

##### 데코레이터(Decorator) 구성요소

- 컴포넌트(Component)   : 토핑에 의해 기능이 추가될 클래스(꾸며질 대상)
- 데코레이터(Decorator) : 공통 클래스의 구조를 전달하는 역할.
  - 토핑으로 컴포넌트를 데코레이션(Decoration) 할 수 있게 만드는 역할.
- 토핑(Topping)         : 데코레이터를 이용해 컴포넌트에 추가할 기능이 담긴 클래스

#### 퍼사드(Facade)

- 복잡한 내부 로직을 감추고 클라이언트가 쉽게 접근할 수 있는 인터페이스를 제공합니다.
  - > 자판기에서 상품을 구매하기 위해 버튼을 누를 뿐 상품이 나오는 과정을 알 필요는 없습니다.

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
