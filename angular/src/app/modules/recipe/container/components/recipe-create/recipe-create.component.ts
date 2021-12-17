import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray, AbstractControl } from '@angular/forms';

import { RecipeService } from '../../../services/recipe.service';

import { CreateRecipeRequestModel } from '../../../models/request-models/create-recipe-request.model';
import { CreateRecipeIngredientListItemRequestModel } from '../../../models/request-models/create-recipe-ingredient-list-item-request.model';

@Component({
  selector: 'app-recipe-create',
  templateUrl: './recipe-create.component.html',
  styleUrls: ['./recipe-create.component.scss'],
})
export class RecipeCreateComponent implements OnInit, OnDestroy {
  private subscriptions: Subscription[] = [];

  public recipeForm: FormGroup;

  public recipeName(): AbstractControl {
    return this.recipeForm.get('name');
  }

  public recipeDescription(): AbstractControl {
    return this.recipeForm.get('description');
  }

  public get ingredients(): FormArray {
    return <FormArray>this.recipeForm.get('ingredients');
  }

  public ingredientName(index: number): AbstractControl {
    return this.ingredients.at(index).get('name');
  }

  public constructor(
    private router: Router,
    private route: ActivatedRoute,
    private recipeService: RecipeService,
  ) {}

  public ngOnInit(): void {
    this.recipeForm = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      description: new FormControl(null, [Validators.required]),
      ingredients: new FormArray([]),
    });

    this.subscriptions.push(
      this.recipeService.recipeItemCreated$.subscribe(() => {
        this.router.navigate(['../'], { relativeTo: this.route });
      })
    );
  }

  public ngOnDestroy(): void {
    this.subscriptions.forEach(x => x.unsubscribe());
  }

  public onAddNewRecipeIngredient(): void {
    this.ingredients.push(this.createNewRecipeIngredientFormGroup());
  }

  public onDeleteRecipeIngredient(arrayIndex: number): void {
    if (arrayIndex !== null && arrayIndex !== undefined && arrayIndex >= 0) {
      this.ingredients.removeAt(arrayIndex);
    }
  }

  public onCreateRecipe(): void {
    const requestModel: CreateRecipeRequestModel = {
      name: this.recipeName().value,
      description: this.recipeDescription().value,
      ingredients: this.ingredients.controls.map(
        item =>
          ({
            name: item.get('name').value,
          } as CreateRecipeIngredientListItemRequestModel)
      ),
    } as CreateRecipeRequestModel;

    this.recipeService.createRecipe(requestModel);
  }

  public onCancel(): void {
    this.router.navigate(['../'], { relativeTo: this.route });
  }

  private createNewRecipeIngredientFormGroup(): FormGroup {
    return new FormGroup({
      name: new FormControl(null, Validators.required),
    });
  }
}
