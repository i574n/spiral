program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Recursive0 = class
    RefCount: LongInt;
    Tag: LongInt;
    v0: LongInt;
    v1: Recursive0;
  end;

function RecursiveCreate0_0: Recursive0;
begin
  Result := Recursive0.Create;
  Result.RefCount := 1;
  Result.Tag := 0;
end;
function RecursiveCreate0_1(v0: LongInt; v1: Recursive0): Recursive0;
begin
  Result := Recursive0.Create;
  Result.RefCount := 1;
  Result.Tag := 1;
  Result.v0 := v0;
  Result.v1 := v1;
end;
function RecursiveTag0(value: Recursive0): LongInt;
begin
  Result := value.Tag;
end;
function RecursiveField0_0(value: Recursive0): LongInt;
begin
  if value.Tag <> 1 then raise EVariantError.Create('recursive union field requested from wrong case');
  Result := value.v0;
end;
function RecursiveField0_1(value: Recursive0): Recursive0;
begin
  if value.Tag <> 1 then raise EVariantError.Create('recursive union field requested from wrong case');
  Result := value.v1;
end;
procedure RecursiveClone0(value: Recursive0);
begin
  if value <> nil then Inc(value.RefCount);
end;
procedure RecursiveDrop0(var value: Recursive0);
var
  child: Recursive0;
begin
  if value = nil then Exit;
  Dec(value.RefCount);
  if value.RefCount = 0 then
  begin
    child := nil;
    if value.Tag = 1 then child := value.v1;
    value.Free;
    value := nil;
    if child <> nil then RecursiveDrop0(child);
  end
  else value := nil;
end;

function sum0(v0: Recursive0): LongInt;
var
  v1: LongInt;
  v2: Recursive0;
  v3: LongInt;
  v4: LongInt;
begin
  if (RecursiveTag0(v0) = 1) then begin
    v1 := RecursiveField0_0(v0);
    v2 := RecursiveField0_1(v0);
    RecursiveClone0(v2);
    RecursiveClone0(v2);
    RecursiveDrop0(v0);
    v3 := sum0(v2);
    RecursiveDrop0(v2);
    v4 := (v1 + v3);
    Exit(v4);
  end else begin
    RecursiveDrop0(v0);
    Exit(0);
  end;
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: Recursive0;
  v4: Recursive0;
  v5: Recursive0;
  v6: Recursive0;
  v7: LongInt;
  v8: LongInt;
begin
  v0 := 1;
  v1 := 2;
  v2 := 3;
  v3 := RecursiveCreate0_0();
  RecursiveClone0(v3);
  v4 := RecursiveCreate0_1(v2, v3);
  RecursiveClone0(v4);
  RecursiveDrop0(v3);
  v5 := RecursiveCreate0_1(v1, v4);
  RecursiveClone0(v5);
  RecursiveDrop0(v4);
  v6 := RecursiveCreate0_1(v0, v5);
  RecursiveClone0(v6);
  RecursiveDrop0(v5);
  v7 := sum0(v6);
  RecursiveDrop0(v6);
  v8 := (v7 - 6);
  Exit(v8);
end;

begin
  Halt(SpiralMain);
end.
