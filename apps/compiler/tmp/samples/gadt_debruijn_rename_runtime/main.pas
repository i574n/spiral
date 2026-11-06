program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TUH0 = class;
  TUH1 = class;
  TFun0 = class;
  TFun1 = class;
  TFun2 = class;
  TUH0 = class(TSpiralRc) tag: LongInt; c1_0: TUH0; procedure DropFields; override; end;
  TUH1 = class(TSpiralRc) tag: LongInt; c0_0: TUH0; c1_0: TUH1; c2_0: TUH1; c2_1: TUH1; procedure DropFields; override; end;
  TFun0 = class(TSpiralRc)
    function Invoke(a0: TUH0): TUH0; virtual; abstract;
  end;
  Tclosure0 = class(TFun0)  function Invoke(v0: TUH0): TUH0; override; end;
  TFun1 = class(TSpiralRc)
    function Invoke(a0: TUH0): TUH0; virtual; abstract;
  end;
  Tclosure1 = class(TFun1) v0: TFun0; function Invoke(v1: TUH0): TUH0; override; procedure DropFields; override; end;
  TFun2 = class(TSpiralRc)
    function Invoke(a0: TUH0): TUH0; virtual; abstract;
  end;
  Tclosure2 = class(TFun2) v0: TFun1; function Invoke(v1: TUH0): TUH0; override; procedure DropFields; override; end;
  Tclosure3 = class(TFun2) v0: TFun2; function Invoke(v1: TUH0): TUH0; override; procedure DropFields; override; end;
procedure TSpiralRc.DropFields;
begin
end;
procedure SpiralRetain(o: TSpiralRc);
begin
  if o <> nil then Inc(o.refc);
end;
procedure SpiralRelease(o: TSpiralRc);
begin
  if o <> nil then begin Dec(o.refc); if o.refc < 0 then begin o.DropFields; o.Free; end; end;
end;
function SpiralKeep(o: TSpiralRc): TSpiralRc;
begin
  SpiralRetain(o); Result := o;
end;
function ClosureCreate0: TFun0; forward;
function ClosureCreate1(v0: TFun0): TFun1; forward;
function ClosureCreate2(v0: TFun1): TFun2; forward;
function ClosureCreate3(v0: TFun2): TFun2; forward;
function rename_5(v0: TFun2; v1: TUH1): TUH1; forward;
function rename_4(v0: TFun2; v1: TUH1): TUH1; forward;
function rename_3(v0: TFun1; v1: TUH1): TUH1; forward;
function rename_2(v0: TFun1; v1: TUH1): TUH1; forward;
function rename_1(v0: TFun0; v1: TUH1): TUH1; forward;
function rename_0(v0: TFun0; v1: TUH1): TUH1; forward;
function size_9(v0: TUH1): LongInt; forward;
function size_8(v0: TUH1): LongInt; forward;
function size_7(v0: TUH1): LongInt; forward;
function size_6(v0: TUH1): LongInt; forward;
procedure TUH0.DropFields;
begin
  SpiralRelease(c1_0);
end;
var UH0_VZ_shared: TUH0 = nil;
function UH0_VZ: TUH0;
begin
  if UH0_VZ_shared = nil then begin UH0_VZ_shared := TUH0.Create; UH0_VZ_shared.tag := 0; UH0_VZ_shared.refc := High(LongInt) div 2; end;
  Result := UH0_VZ_shared;
end;
function UH0_VS(a0: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; Result.c1_0 := a0;
end;
procedure TUH1.DropFields;
begin
  SpiralRelease(c0_0); SpiralRelease(c1_0); SpiralRelease(c2_0); SpiralRelease(c2_1);
end;
function UH1_Var(a0: TUH0): TUH1;
begin
  Result := TUH1.Create; Result.tag := 0; Result.c0_0 := a0;
end;
function UH1_Lam(a0: TUH1): TUH1;
begin
  Result := TUH1.Create; Result.tag := 1; Result.c1_0 := a0;
end;
function UH1_App(a0: TUH1; a1: TUH1): TUH1;
begin
  Result := TUH1.Create; Result.tag := 2; Result.c2_0 := a0; Result.c2_1 := a1;
end;
function Tclosure0.Invoke(v0: TUH0): TUH0;
begin
  Result := UH0_VS(v0);
  SpiralRelease(Self);
end;
function ClosureCreate0: TFun0;
var c: Tclosure0;
begin
  c := Tclosure0.Create; 
  Result := c;
end;
procedure Tclosure1.DropFields;
begin
  SpiralRelease(v0);
end;
function Tclosure1.Invoke(v1: TUH0): TUH0;
var
  v3: TUH0;
  v4: TUH0;
begin
  case v1.tag of
      1: begin
          v3 := v1.c1_0;
          SpiralRetain(v0);
          SpiralRetain(v3);
          SpiralRetain(v3);
          SpiralRelease(v1);
          v4 := v0.Invoke(v3);
          SpiralRelease(v3);
          Result := UH0_VS(v4);
      end;
      0: begin
          SpiralRelease(v1);
          Result := UH0_VZ;
      end;
  end;
  SpiralRelease(Self);
end;
function ClosureCreate1(v0: TFun0): TFun1;
var c: Tclosure1;
begin
  c := Tclosure1.Create; c.v0 := v0;
  Result := c;
end;
procedure Tclosure2.DropFields;
begin
  SpiralRelease(v0);
end;
function Tclosure2.Invoke(v1: TUH0): TUH0;
var
  v3: TUH0;
  v4: TUH0;
begin
  case v1.tag of
      1: begin
          v3 := v1.c1_0;
          SpiralRetain(v0);
          SpiralRetain(v3);
          SpiralRetain(v3);
          SpiralRelease(v1);
          v4 := v0.Invoke(v3);
          SpiralRelease(v3);
          Result := UH0_VS(v4);
      end;
      0: begin
          SpiralRelease(v1);
          Result := UH0_VZ;
      end;
  end;
  SpiralRelease(Self);
end;
function ClosureCreate2(v0: TFun1): TFun2;
var c: Tclosure2;
begin
  c := Tclosure2.Create; c.v0 := v0;
  Result := c;
end;
procedure Tclosure3.DropFields;
begin
  SpiralRelease(v0);
end;
function Tclosure3.Invoke(v1: TUH0): TUH0;
var
  v3: TUH0;
  v4: TUH0;
begin
  case v1.tag of
      1: begin
          v3 := v1.c1_0;
          SpiralRetain(v0);
          SpiralRetain(v3);
          SpiralRetain(v3);
          SpiralRelease(v1);
          v4 := v0.Invoke(v3);
          SpiralRelease(v3);
          Result := UH0_VS(v4);
      end;
      0: begin
          SpiralRelease(v1);
          Result := UH0_VZ;
      end;
  end;
  SpiralRelease(Self);
end;
function ClosureCreate3(v0: TFun2): TFun2;
var c: Tclosure3;
begin
  c := Tclosure3.Create; c.v0 := v0;
  Result := c;
end;
function rename_5(v0: TFun2; v1: TUH1): TUH1;
var
  v9: TUH1;
  v10: TUH1;
  v11: TUH1;
  v12: TUH1;
  v5: TUH1;
  v6: TFun2;
  v7: TUH1;
  v2: TUH0;
  v3: TUH0;
begin
  case v1.tag of
      2: begin
          v9 := v1.c2_0;
          v10 := v1.c2_1;
          SpiralRetain(v0);
          SpiralRetain(v9);
          SpiralRetain(v9);
          SpiralRetain(v10);
          SpiralRelease(v1);
          v11 := rename_5(v0, v9);
          SpiralRetain(v0);
          SpiralRetain(v10);
          SpiralRelease(v9);
          v12 := rename_5(v0, v10);
          SpiralRelease(v0);
          SpiralRelease(v10);
          Result := UH1_App(v11, v12);
      end;
      1: begin
          v5 := v1.c1_0;
          SpiralRetain(v0);
          SpiralRetain(v5);
          SpiralRelease(v1);
          v6 := ClosureCreate3(v0);
          SpiralRetain(v5);
          SpiralRetain(v6);
          SpiralRelease(v0);
          v7 := rename_4(v6, v5);
          SpiralRelease(v5);
          SpiralRelease(v6);
          Result := UH1_Lam(v7);
      end;
      0: begin
          v2 := v1.c0_0;
          SpiralRetain(v0);
          SpiralRetain(v2);
          SpiralRetain(v2);
          SpiralRelease(v1);
          v3 := v0.Invoke(v2);
          SpiralRelease(v0);
          SpiralRelease(v2);
          Result := UH1_Var(v3);
      end;
  end;
end;
function rename_4(v0: TFun2; v1: TUH1): TUH1;
var
  v9: TUH1;
  v10: TUH1;
  v11: TUH1;
  v12: TUH1;
  v5: TUH1;
  v6: TFun2;
  v7: TUH1;
  v2: TUH0;
  v3: TUH0;
begin
  case v1.tag of
      2: begin
          v9 := v1.c2_0;
          v10 := v1.c2_1;
          SpiralRetain(v0);
          SpiralRetain(v9);
          SpiralRetain(v9);
          SpiralRetain(v10);
          SpiralRelease(v1);
          v11 := rename_5(v0, v9);
          SpiralRetain(v0);
          SpiralRetain(v10);
          SpiralRelease(v9);
          v12 := rename_5(v0, v10);
          SpiralRelease(v0);
          SpiralRelease(v10);
          Result := UH1_App(v11, v12);
      end;
      1: begin
          v5 := v1.c1_0;
          SpiralRetain(v0);
          SpiralRetain(v5);
          SpiralRelease(v1);
          v6 := ClosureCreate3(v0);
          SpiralRetain(v5);
          SpiralRetain(v6);
          SpiralRelease(v0);
          v7 := rename_4(v6, v5);
          SpiralRelease(v5);
          SpiralRelease(v6);
          Result := UH1_Lam(v7);
      end;
      0: begin
          v2 := v1.c0_0;
          SpiralRetain(v0);
          SpiralRetain(v2);
          SpiralRetain(v2);
          SpiralRelease(v1);
          v3 := v0.Invoke(v2);
          SpiralRelease(v0);
          SpiralRelease(v2);
          Result := UH1_Var(v3);
      end;
  end;
end;
function rename_3(v0: TFun1; v1: TUH1): TUH1;
var
  v9: TUH1;
  v10: TUH1;
  v11: TUH1;
  v12: TUH1;
  v5: TUH1;
  v6: TFun2;
  v7: TUH1;
  v2: TUH0;
  v3: TUH0;
begin
  case v1.tag of
      2: begin
          v9 := v1.c2_0;
          v10 := v1.c2_1;
          SpiralRetain(v0);
          SpiralRetain(v9);
          SpiralRetain(v9);
          SpiralRetain(v10);
          SpiralRelease(v1);
          v11 := rename_3(v0, v9);
          SpiralRetain(v0);
          SpiralRetain(v10);
          SpiralRelease(v9);
          v12 := rename_3(v0, v10);
          SpiralRelease(v0);
          SpiralRelease(v10);
          Result := UH1_App(v11, v12);
      end;
      1: begin
          v5 := v1.c1_0;
          SpiralRetain(v0);
          SpiralRetain(v5);
          SpiralRelease(v1);
          v6 := ClosureCreate2(v0);
          SpiralRetain(v5);
          SpiralRetain(v6);
          SpiralRelease(v0);
          v7 := rename_4(v6, v5);
          SpiralRelease(v5);
          SpiralRelease(v6);
          Result := UH1_Lam(v7);
      end;
      0: begin
          v2 := v1.c0_0;
          SpiralRetain(v0);
          SpiralRetain(v2);
          SpiralRetain(v2);
          SpiralRelease(v1);
          v3 := v0.Invoke(v2);
          SpiralRelease(v0);
          SpiralRelease(v2);
          Result := UH1_Var(v3);
      end;
  end;
end;
function rename_2(v0: TFun1; v1: TUH1): TUH1;
var
  v9: TUH1;
  v10: TUH1;
  v11: TUH1;
  v12: TUH1;
  v5: TUH1;
  v6: TFun2;
  v7: TUH1;
  v2: TUH0;
  v3: TUH0;
begin
  case v1.tag of
      2: begin
          v9 := v1.c2_0;
          v10 := v1.c2_1;
          SpiralRetain(v0);
          SpiralRetain(v9);
          SpiralRetain(v9);
          SpiralRetain(v10);
          SpiralRelease(v1);
          v11 := rename_3(v0, v9);
          SpiralRetain(v0);
          SpiralRetain(v10);
          SpiralRelease(v9);
          v12 := rename_3(v0, v10);
          SpiralRelease(v0);
          SpiralRelease(v10);
          Result := UH1_App(v11, v12);
      end;
      1: begin
          v5 := v1.c1_0;
          SpiralRetain(v0);
          SpiralRetain(v5);
          SpiralRelease(v1);
          v6 := ClosureCreate2(v0);
          SpiralRetain(v5);
          SpiralRetain(v6);
          SpiralRelease(v0);
          v7 := rename_4(v6, v5);
          SpiralRelease(v5);
          SpiralRelease(v6);
          Result := UH1_Lam(v7);
      end;
      0: begin
          v2 := v1.c0_0;
          SpiralRetain(v0);
          SpiralRetain(v2);
          SpiralRetain(v2);
          SpiralRelease(v1);
          v3 := v0.Invoke(v2);
          SpiralRelease(v0);
          SpiralRelease(v2);
          Result := UH1_Var(v3);
      end;
  end;
end;
function rename_1(v0: TFun0; v1: TUH1): TUH1;
var
  v9: TUH1;
  v10: TUH1;
  v11: TUH1;
  v12: TUH1;
  v5: TUH1;
  v6: TFun1;
  v7: TUH1;
  v2: TUH0;
  v3: TUH0;
begin
  case v1.tag of
      2: begin
          v9 := v1.c2_0;
          v10 := v1.c2_1;
          SpiralRetain(v0);
          SpiralRetain(v9);
          SpiralRetain(v9);
          SpiralRetain(v10);
          SpiralRelease(v1);
          v11 := rename_1(v0, v9);
          SpiralRetain(v0);
          SpiralRetain(v10);
          SpiralRelease(v9);
          v12 := rename_1(v0, v10);
          SpiralRelease(v0);
          SpiralRelease(v10);
          Result := UH1_App(v11, v12);
      end;
      1: begin
          v5 := v1.c1_0;
          SpiralRetain(v0);
          SpiralRetain(v5);
          SpiralRelease(v1);
          v6 := ClosureCreate1(v0);
          SpiralRetain(v5);
          SpiralRetain(v6);
          SpiralRelease(v0);
          v7 := rename_2(v6, v5);
          SpiralRelease(v5);
          SpiralRelease(v6);
          Result := UH1_Lam(v7);
      end;
      0: begin
          v2 := v1.c0_0;
          SpiralRetain(v0);
          SpiralRetain(v2);
          SpiralRetain(v2);
          SpiralRelease(v1);
          v3 := v0.Invoke(v2);
          SpiralRelease(v0);
          SpiralRelease(v2);
          Result := UH1_Var(v3);
      end;
  end;
end;
function rename_0(v0: TFun0; v1: TUH1): TUH1;
var
  v9: TUH1;
  v10: TUH1;
  v11: TUH1;
  v12: TUH1;
  v5: TUH1;
  v6: TFun1;
  v7: TUH1;
  v2: TUH0;
  v3: TUH0;
begin
  case v1.tag of
      2: begin
          v9 := v1.c2_0;
          v10 := v1.c2_1;
          SpiralRetain(v0);
          SpiralRetain(v9);
          SpiralRetain(v9);
          SpiralRetain(v10);
          SpiralRelease(v1);
          v11 := rename_1(v0, v9);
          SpiralRetain(v0);
          SpiralRetain(v10);
          SpiralRelease(v9);
          v12 := rename_1(v0, v10);
          SpiralRelease(v0);
          SpiralRelease(v10);
          Result := UH1_App(v11, v12);
      end;
      1: begin
          v5 := v1.c1_0;
          SpiralRetain(v0);
          SpiralRetain(v5);
          SpiralRelease(v1);
          v6 := ClosureCreate1(v0);
          SpiralRetain(v5);
          SpiralRetain(v6);
          SpiralRelease(v0);
          v7 := rename_2(v6, v5);
          SpiralRelease(v5);
          SpiralRelease(v6);
          Result := UH1_Lam(v7);
      end;
      0: begin
          v2 := v1.c0_0;
          SpiralRetain(v0);
          SpiralRetain(v2);
          SpiralRetain(v2);
          SpiralRelease(v1);
          v3 := v0.Invoke(v2);
          SpiralRelease(v0);
          SpiralRelease(v2);
          Result := UH1_Var(v3);
      end;
  end;
end;
function size_9(v0: TUH1): LongInt;
var
  v5: TUH1;
  v6: TUH1;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v2: TUH1;
  v3: LongInt;
  v4: LongInt;
  v1: TUH0;
begin
  case v0.tag of
      2: begin
          v5 := v0.c2_0;
          v6 := v0.c2_1;
          SpiralRetain(v5);
          SpiralRetain(v5);
          SpiralRetain(v6);
          SpiralRelease(v0);
          v7 := size_9(v5);
          SpiralRelease(v5);
          v8 := 1 + v7;
          SpiralRetain(v6);
          v9 := size_9(v6);
          SpiralRelease(v6);
          v10 := v8 + v9;
          Result := v10;
      end;
      1: begin
          v2 := v0.c1_0;
          SpiralRetain(v2);
          SpiralRetain(v2);
          SpiralRelease(v0);
          v3 := size_8(v2);
          SpiralRelease(v2);
          v4 := 1 + v3;
          Result := v4;
      end;
      0: begin
          v1 := v0.c0_0;
          SpiralRelease(v0);
          Result := 1;
      end;
  end;
end;
function size_8(v0: TUH1): LongInt;
var
  v5: TUH1;
  v6: TUH1;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v2: TUH1;
  v3: LongInt;
  v4: LongInt;
  v1: TUH0;
begin
  case v0.tag of
      2: begin
          v5 := v0.c2_0;
          v6 := v0.c2_1;
          SpiralRetain(v5);
          SpiralRetain(v5);
          SpiralRetain(v6);
          SpiralRelease(v0);
          v7 := size_9(v5);
          SpiralRelease(v5);
          v8 := 1 + v7;
          SpiralRetain(v6);
          v9 := size_9(v6);
          SpiralRelease(v6);
          v10 := v8 + v9;
          Result := v10;
      end;
      1: begin
          v2 := v0.c1_0;
          SpiralRetain(v2);
          SpiralRetain(v2);
          SpiralRelease(v0);
          v3 := size_8(v2);
          SpiralRelease(v2);
          v4 := 1 + v3;
          Result := v4;
      end;
      0: begin
          v1 := v0.c0_0;
          SpiralRelease(v0);
          Result := 1;
      end;
  end;
end;
function size_7(v0: TUH1): LongInt;
var
  v5: TUH1;
  v6: TUH1;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v2: TUH1;
  v3: LongInt;
  v4: LongInt;
  v1: TUH0;
begin
  case v0.tag of
      2: begin
          v5 := v0.c2_0;
          v6 := v0.c2_1;
          SpiralRetain(v5);
          SpiralRetain(v5);
          SpiralRetain(v6);
          SpiralRelease(v0);
          v7 := size_7(v5);
          SpiralRelease(v5);
          v8 := 1 + v7;
          SpiralRetain(v6);
          v9 := size_7(v6);
          SpiralRelease(v6);
          v10 := v8 + v9;
          Result := v10;
      end;
      1: begin
          v2 := v0.c1_0;
          SpiralRetain(v2);
          SpiralRetain(v2);
          SpiralRelease(v0);
          v3 := size_8(v2);
          SpiralRelease(v2);
          v4 := 1 + v3;
          Result := v4;
      end;
      0: begin
          v1 := v0.c0_0;
          SpiralRelease(v0);
          Result := 1;
      end;
  end;
end;
function size_6(v0: TUH1): LongInt;
var
  v5: TUH1;
  v6: TUH1;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v2: TUH1;
  v3: LongInt;
  v4: LongInt;
  v1: TUH0;
begin
  case v0.tag of
      2: begin
          v5 := v0.c2_0;
          v6 := v0.c2_1;
          SpiralRetain(v5);
          SpiralRetain(v5);
          SpiralRetain(v6);
          SpiralRelease(v0);
          v7 := size_7(v5);
          SpiralRelease(v5);
          v8 := 1 + v7;
          SpiralRetain(v6);
          v9 := size_7(v6);
          SpiralRelease(v6);
          v10 := v8 + v9;
          Result := v10;
      end;
      1: begin
          v2 := v0.c1_0;
          SpiralRetain(v2);
          SpiralRetain(v2);
          SpiralRelease(v0);
          v3 := size_8(v2);
          SpiralRelease(v2);
          v4 := 1 + v3;
          Result := v4;
      end;
      0: begin
          v1 := v0.c0_0;
          SpiralRelease(v0);
          Result := 1;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: TUH0;
  v1: TUH1;
  v2: TUH0;
  v3: TUH0;
  v4: TUH1;
  v5: TUH1;
  v6: TUH1;
  v7: TUH1;
  v8: TFun0;
  v9: TUH1;
begin
  v0 := UH0_VZ;
  SpiralRetain(v0);
  v1 := UH1_Var(v0);
  SpiralRelease(v0);
  v2 := UH0_VZ;
  SpiralRetain(v2);
  v3 := UH0_VS(v2);
  SpiralRetain(v3);
  SpiralRelease(v2);
  v4 := UH1_Var(v3);
  SpiralRetain(v4);
  SpiralRelease(v3);
  v5 := UH1_Lam(v4);
  SpiralRetain(v1);
  SpiralRetain(v5);
  SpiralRelease(v4);
  v6 := UH1_App(v1, v5);
  SpiralRetain(v6);
  SpiralRelease(v1);
  SpiralRelease(v5);
  v7 := UH1_Lam(v6);
  SpiralRelease(v6);
  v8 := ClosureCreate0;
  SpiralRetain(v7);
  SpiralRetain(v8);
  v9 := rename_0(v8, v7);
  SpiralRelease(v7);
  SpiralRelease(v8);
  Result := size_6(v9);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
var SpiralExitCode: LongInt;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  SpiralExitCode := SpiralMain;
  if UH0_VZ_shared <> nil then UH0_VZ_shared.Free;
  Halt(SpiralExitCode);
end.
